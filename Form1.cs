using System.Diagnostics;
using System.Text;

namespace BinaryClock
{
    public partial class Form1 : Form
    {
        #region Enums
        internal enum DisplayMode
        {
            Bin,
            Oct,
            Dec,
            Hex
        }

        internal enum FontSize
        {
            Small = 12,
            Medium = 18,
            Large = 24
        }

        internal enum TimeComp
        {
            Hour,
            Minute,
            Second
        };
        #endregion

        #region Vars/Properties
        private DisplayMode displayMode = DisplayMode.Bin;
        private FontSize fontSize = FontSize.Medium;
        private bool isVertical;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, this.fontSize, this.isVertical);

        private void ChangeLayout(DisplayMode displayMode, FontSize fontSize, bool isVertical)
        {
            this.displayMode = displayMode;
            this.isVertical = isVertical;
            this.fontSize = fontSize;
            this.UpdateLayout();
            this.UpdateMenuChecks();
        }

        private void UpdateLayout()
        {
            // measure required size for the contents of one label
            using var gfx = Graphics.FromHwnd(this.Handle);
            using var font = new Font(this.Font.FontFamily, (int)this.fontSize, FontStyle.Bold);
            var measureString = (this.displayMode == DisplayMode.Bin ? " 00 0000 0" : " 00 0");
            var size = gfx.MeasureString(measureString, font).ToSize();

            // resize labels + fonts
            this.hours.Font = this.minutes.Font = this.seconds.Font = font;
            this.hours.Size = this.minutes.Size = this.seconds.Size = size;

            // resize form
            if (this.isVertical)
            {
                size.Height *= 3;
                size.Height += 2 * this.Padding.Vertical;
                size.Width += this.Padding.Horizontal;
            }
            else
            {
                size.Width *= 3;
                size.Width += 2 * this.Padding.Horizontal;
                size.Height += this.Padding.Vertical;
            }
            this.Size = size;

            // reposition label controls
            this.hours.Location = new Point(this.Padding.Left, this.Padding.Top);
            if (this.isVertical)
            {
                this.minutes.Location = new Point(this.Padding.Left, this.hours.Location.Y + this.hours.Height + (this.Padding.Vertical >> 1));
                this.seconds.Location = new Point(this.Padding.Left, this.ClientSize.Height - this.seconds.Height - this.Padding.Bottom);
            }
            else
            {
                this.minutes.Location = new Point(this.hours.Location.X + this.hours.Size.Width + (this.Padding.Horizontal >> 1), this.Padding.Top);
                this.seconds.Location = new Point(this.ClientSize.Width - this.seconds.Width - this.Padding.Right, this.Padding.Top);
            }
        }

        private static string FormatTime(DateTime time, TimeComp timeComp, DisplayMode displayMode)
        {
            // 1. pick time component (h/m/s)
            var value = 0;
            switch (timeComp)
            {
                case TimeComp.Hour:
                    value = time.Hour;
                    break;
                case TimeComp.Minute:
                    value = time.Minute;
                    break;
                case TimeComp.Second:
                    value = time.Second;
                    break;
                default:
                    throw new ArgumentException($"unknown Time component: {timeComp}", nameof(timeComp));
            }

            // 2. format number, according to display mode
            var result = new StringBuilder(16);
            switch (displayMode)
            {
                case DisplayMode.Bin:
                    {
                        var digits = (timeComp == TimeComp.Hour ? 5 : 6);
                        // run through bits
                        while (digits-- > 0)
                        {
                            var pos = 0x01 << digits;
                            // space out nibbles
                            if (digits == 3)
                            {
                                result.Append(' ');
                            }
                            result.Append((value & pos) > 0 ? '●' : '○');
                        }
                    }
                    break;
                case DisplayMode.Oct:
                    {
                        var octal = value / 8 * 10 + value % 8;
                        result.Append(octal.ToString("D2"));
                    }
                    break;
                case DisplayMode.Dec:
                    result.Append(value.ToString("D2"));
                    break;
                case DisplayMode.Hex:
                    result.Append(value.ToString("X2"));
                    break;
                default:
                    break;
            }

            // 3. add h/m/s identifier
            switch (timeComp)
            {
                case TimeComp.Hour:
                    result.Append(" h");
                    break;
                case TimeComp.Minute:
                    result.Append(" m");
                    break;
                case TimeComp.Second:
                    result.Append(" s");
                    break;
            }
            return result.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            this.hours.Text = FormatTime(time, TimeComp.Hour, this.displayMode);
            this.minutes.Text = FormatTime(time, TimeComp.Minute, this.displayMode);
            this.seconds.Text = FormatTime(time, TimeComp.Second, this.displayMode);
        }

        #region Mouse stuff
        private Point LastLocation { get; set; }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Control ctl)
            {
                this.Capture = true;
                this.LastLocation = ctl.PointToScreen(e.Location);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.Capture || sender is not Control ctl)
            {
                return;
            }
            // calculate diff
            var currentLocation = ctl.PointToScreen(e.Location);
            var diff = currentLocation - ((Size)this.LastLocation);
            // calculate new position
            var newPos = this.Location;
            newPos.Offset(diff);
            this.Location = newPos;
            // remember current position
            this.LastLocation = currentLocation;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
        }
        #endregion

        #region Menu stuff
        private void UpdateMenuChecks()
        {
            // DisplayMode
            this.binaryToolStripMenuItem.Checked = this.displayMode == DisplayMode.Bin;
            this.octalToolStripMenuItem.Checked = this.displayMode == DisplayMode.Oct;
            this.decimalToolStripMenuItem.Checked = this.displayMode == DisplayMode.Dec;
            this.hexadecimalToolStripMenuItem.Checked = this.displayMode == DisplayMode.Hex;

            // FontSize
            this.smallToolStripMenuItem.Checked = this.fontSize == FontSize.Small;
            this.mediumToolStripMenuItem.Checked = this.fontSize == FontSize.Medium;
            this.largeToolStripMenuItem.Checked = this.fontSize == FontSize.Large;

            // Layout
            this.horizontalToolStripMenuItem.Checked = !this.isVertical;
            this.verticalToolStripMenuItem.Checked = this.isVertical;
        }

        // DisplayMode
        private void binaryToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(DisplayMode.Bin, this.fontSize, this.isVertical);

        private void octalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(DisplayMode.Oct, this.fontSize, this.isVertical);

        private void decimalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(DisplayMode.Dec, this.fontSize, this.isVertical);

        private void hexadecimalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(DisplayMode.Hex, this.fontSize, this.isVertical);

        // FontSize
        private void smallToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, FontSize.Small, this.isVertical);

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, FontSize.Medium, this.isVertical);

        private void largeToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, FontSize.Large, this.isVertical);


        // Layout
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, this.fontSize, false);

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.displayMode, this.fontSize, true);

        // General
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        #endregion
    }
}
