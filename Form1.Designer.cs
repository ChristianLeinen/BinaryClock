namespace BinaryClock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            hours = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            modeToolStripMenuItem = new ToolStripMenuItem();
            binaryToolStripMenuItem = new ToolStripMenuItem();
            octalToolStripMenuItem = new ToolStripMenuItem();
            decimalToolStripMenuItem = new ToolStripMenuItem();
            hexadecimalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            largeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            horizontalToolStripMenuItem = new ToolStripMenuItem();
            verticalToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            minutes = new Label();
            seconds = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // hours
            // 
            hours.BorderStyle = BorderStyle.FixedSingle;
            hours.ContextMenuStrip = contextMenuStrip1;
            hours.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hours.ForeColor = Color.FromArgb(0, 192, 0);
            hours.Location = new Point(5, 5);
            hours.Margin = new Padding(6, 0, 6, 0);
            hours.Name = "hours";
            hours.Size = new Size(180, 40);
            hours.TabIndex = 0;
            hours.Text = "●○ ●○● h";
            hours.TextAlign = ContentAlignment.TopRight;
            hours.MouseCaptureChanged += Form1_MouseCaptureChanged;
            hours.MouseDown += Form1_MouseDown;
            hours.MouseMove += Form1_MouseMove;
            hours.MouseUp += Form1_MouseUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { modeToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem1, horizontalToolStripMenuItem, verticalToolStripMenuItem, toolStripSeparator1, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(168, 146);
            // 
            // modeToolStripMenuItem
            // 
            modeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { binaryToolStripMenuItem, octalToolStripMenuItem, decimalToolStripMenuItem, hexadecimalToolStripMenuItem });
            modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            modeToolStripMenuItem.Size = new Size(167, 26);
            modeToolStripMenuItem.Text = "&Mode";
            // 
            // binaryToolStripMenuItem
            // 
            binaryToolStripMenuItem.Checked = true;
            binaryToolStripMenuItem.CheckState = CheckState.Checked;
            binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            binaryToolStripMenuItem.Size = new Size(224, 26);
            binaryToolStripMenuItem.Text = "&Binary";
            binaryToolStripMenuItem.Click += binaryToolStripMenuItem_Click;
            // 
            // octalToolStripMenuItem
            // 
            octalToolStripMenuItem.Name = "octalToolStripMenuItem";
            octalToolStripMenuItem.Size = new Size(224, 26);
            octalToolStripMenuItem.Text = "&Octal";
            octalToolStripMenuItem.Click += octalToolStripMenuItem_Click;
            // 
            // decimalToolStripMenuItem
            // 
            decimalToolStripMenuItem.Name = "decimalToolStripMenuItem";
            decimalToolStripMenuItem.Size = new Size(224, 26);
            decimalToolStripMenuItem.Text = "&Decimal";
            decimalToolStripMenuItem.Click += decimalToolStripMenuItem_Click;
            // 
            // hexadecimalToolStripMenuItem
            // 
            hexadecimalToolStripMenuItem.Name = "hexadecimalToolStripMenuItem";
            hexadecimalToolStripMenuItem.Size = new Size(224, 26);
            hexadecimalToolStripMenuItem.Text = "&Hexadecimal";
            hexadecimalToolStripMenuItem.Click += hexadecimalToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { smallToolStripMenuItem, mediumToolStripMenuItem, largeToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(167, 26);
            toolStripMenuItem2.Text = "&Size";
            // 
            // smallToolStripMenuItem
            // 
            smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            smallToolStripMenuItem.Size = new Size(147, 26);
            smallToolStripMenuItem.Text = "&Small";
            smallToolStripMenuItem.Click += smallToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem
            // 
            mediumToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.CheckState = CheckState.Checked;
            mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            mediumToolStripMenuItem.Size = new Size(147, 26);
            mediumToolStripMenuItem.Text = "&Medium";
            mediumToolStripMenuItem.Click += mediumToolStripMenuItem_Click;
            // 
            // largeToolStripMenuItem
            // 
            largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            largeToolStripMenuItem.Size = new Size(147, 26);
            largeToolStripMenuItem.Text = "&Large";
            largeToolStripMenuItem.Click += largeToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(164, 6);
            // 
            // horizontalToolStripMenuItem
            // 
            horizontalToolStripMenuItem.Checked = true;
            horizontalToolStripMenuItem.CheckState = CheckState.Checked;
            horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            horizontalToolStripMenuItem.Size = new Size(167, 26);
            horizontalToolStripMenuItem.Text = "&Horizontal";
            horizontalToolStripMenuItem.Click += horizontalToolStripMenuItem_Click;
            // 
            // verticalToolStripMenuItem
            // 
            verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            verticalToolStripMenuItem.Size = new Size(167, 26);
            verticalToolStripMenuItem.Text = "&Vertical";
            verticalToolStripMenuItem.Click += verticalToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(164, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            closeToolStripMenuItem.Size = new Size(167, 26);
            closeToolStripMenuItem.Text = "&Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // minutes
            // 
            minutes.BorderStyle = BorderStyle.FixedSingle;
            minutes.ContextMenuStrip = contextMenuStrip1;
            minutes.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            minutes.ForeColor = Color.FromArgb(0, 192, 0);
            minutes.Location = new Point(190, 5);
            minutes.Margin = new Padding(6, 0, 6, 0);
            minutes.Name = "minutes";
            minutes.Size = new Size(180, 40);
            minutes.TabIndex = 1;
            minutes.Text = "○●○ ●○● m";
            minutes.TextAlign = ContentAlignment.TopRight;
            minutes.MouseDown += Form1_MouseDown;
            minutes.MouseMove += Form1_MouseMove;
            minutes.MouseUp += Form1_MouseUp;
            // 
            // seconds
            // 
            seconds.BorderStyle = BorderStyle.FixedSingle;
            seconds.ContextMenuStrip = contextMenuStrip1;
            seconds.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seconds.ForeColor = Color.FromArgb(0, 192, 0);
            seconds.Location = new Point(375, 5);
            seconds.Margin = new Padding(6, 0, 6, 0);
            seconds.Name = "seconds";
            seconds.Size = new Size(180, 40);
            seconds.TabIndex = 2;
            seconds.Text = "○●○ ●○● s";
            seconds.TextAlign = ContentAlignment.TopRight;
            seconds.MouseDown += Form1_MouseDown;
            seconds.MouseMove += Form1_MouseMove;
            seconds.MouseUp += Form1_MouseUp;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(16F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(560, 50);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(seconds);
            Controls.Add(minutes);
            Controls.Add(hours);
            Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Padding = new Padding(5);
            Text = "Binary Clock";
            TopMost = true;
            Load += Form1_Load;
            MouseCaptureChanged += Form1_MouseCaptureChanged;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label hours;
        private Label minutes;
        private Label seconds;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem horizontalToolStripMenuItem;
        private ToolStripMenuItem verticalToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem smallToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem largeToolStripMenuItem;
        private ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem binaryToolStripMenuItem;
        private ToolStripMenuItem octalToolStripMenuItem;
        private ToolStripMenuItem decimalToolStripMenuItem;
        private ToolStripMenuItem hexadecimalToolStripMenuItem;
    }
}
