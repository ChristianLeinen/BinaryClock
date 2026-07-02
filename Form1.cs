using System.Diagnostics;
using System.Text;

namespace BinaryClock
{
    public partial class Form1 : Form
    {
        internal enum TimeComp
        {
            Hour,
            Minute,
            Second
        };

        internal enum FontSize : int
        {
            Small = 12,
            Medium = 18,
            Large = 24
        }

        private int fontSize = (int)FontSize.Medium;
        private bool isVertical;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ChangeLayout(this.isVertical, this.fontSize);
        }

        private void ChangeLayout(bool isVertical, int fontSize)
        {
            this.isVertical = isVertical;
            this.fontSize = fontSize;
            this.UpdateLayout();
            this.UpdateMenuChecks();
        }

        private void UpdateLayout()
        {
            // measure required size for the contents of one label
            using var gfx = Graphics.FromHwnd(this.Handle);
            using var font = new Font(this.Font.FontFamily, this.fontSize, FontStyle.Bold);
            var size = gfx.MeasureString(" 00 0000 0", font).ToSize();

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

        private static string FormatTime(DateTime time, TimeComp timeComp)
        {
            var value = 0;
            var digits = 0;
            switch (timeComp)
            {
                case TimeComp.Hour:
                    value = time.Hour;
                    digits = 5;
                    break;
                case TimeComp.Minute:
                    value = time.Minute;
                    digits = 6;
                    break;
                case TimeComp.Second:
                    value = time.Second;
                    digits = 6;
                    break;
                default:
                    throw new ArgumentException($"unknown Time component: {timeComp}", nameof(timeComp));
            }

            var result = new StringBuilder(16);
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
            this.hours.Text = FormatTime(time, TimeComp.Hour);
            this.minutes.Text = FormatTime(time, TimeComp.Minute);
            this.seconds.Text = FormatTime(time, TimeComp.Second);
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

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Form1_MouseCaptureChanged");
        }
        #endregion

        #region Menu stuff
        private void UpdateMenuChecks()
        {
            this.horizontalToolStripMenuItem.Checked = !this.isVertical;
            this.verticalToolStripMenuItem.Checked = this.isVertical;

            this.smallToolStripMenuItem.Checked = this.fontSize == (int)FontSize.Small;
            this.mediumToolStripMenuItem.Checked = this.fontSize == (int)FontSize.Medium;
            this.largeToolStripMenuItem.Checked = this.fontSize == (int)FontSize.Large;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(false, this.fontSize);

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(true, this.fontSize);

        private void smallToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.isVertical, (int)FontSize.Small);

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.isVertical, (int)FontSize.Medium);

        private void largeToolStripMenuItem_Click(object sender, EventArgs e) => this.ChangeLayout(this.isVertical, (int)FontSize.Large);

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        #endregion
    }
}
