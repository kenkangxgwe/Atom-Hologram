namespace PictureViewer
{
    partial class PictureViewerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FigureBox = new PictureViewer.InterpolationPictureBox();
            this.AxisYPanel = new System.Windows.Forms.Panel();
            this.AxisXPanel = new System.Windows.Forms.Panel();
            this.ColorBarPanel = new System.Windows.Forms.Panel();
            this.ColorBarBox = new System.Windows.Forms.PictureBox();
            this.AxisZPanel = new System.Windows.Forms.Panel();
            this.FigurePanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.FigureBox)).BeginInit();
            this.ColorBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBarBox)).BeginInit();
            this.FigurePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FigureBox
            // 
            this.FigureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FigureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FigureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.FigureBox.Location = new System.Drawing.Point(0, 0);
            this.FigureBox.Name = "FigureBox";
            this.FigureBox.Size = new System.Drawing.Size(522, 407);
            this.FigureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FigureBox.TabIndex = 0;
            this.FigureBox.TabStop = false;
            this.FigureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.FigureBox_Paint);
            this.FigureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FigureBox_MouseDown);
            this.FigureBox.MouseEnter += new System.EventHandler(this.FigureBox_MouseEnter);
            this.FigureBox.MouseLeave += new System.EventHandler(this.FigureBox_MouseLeave);
            this.FigureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FigureBox_MouseMove);
            // 
            // AxisYPanel
            // 
            this.AxisYPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisYPanel.Location = new System.Drawing.Point(0, 0);
            this.AxisYPanel.Name = "AxisYPanel";
            this.AxisYPanel.Size = new System.Drawing.Size(32, 433);
            this.AxisYPanel.TabIndex = 1;
            this.AxisYPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AxisYPanel_Paint);
            // 
            // AxisXPanel
            // 
            this.AxisXPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisXPanel.Location = new System.Drawing.Point(0, 0);
            this.AxisXPanel.Name = "AxisXPanel";
            this.AxisXPanel.Size = new System.Drawing.Size(583, 25);
            this.AxisXPanel.TabIndex = 2;
            this.AxisXPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AxisXPanel_Paint);
            // 
            // ColorBarPanel
            // 
            this.ColorBarPanel.Controls.Add(this.ColorBarBox);
            this.ColorBarPanel.Controls.Add(this.AxisZPanel);
            this.ColorBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorBarPanel.Location = new System.Drawing.Point(0, 0);
            this.ColorBarPanel.Name = "ColorBarPanel";
            this.ColorBarPanel.Size = new System.Drawing.Size(68, 407);
            this.ColorBarPanel.TabIndex = 3;
            // 
            // ColorBarBox
            // 
            this.ColorBarBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorBarBox.Image = global::PictureViewer.Properties.Resources.ParulaColorbar;
            this.ColorBarBox.Location = new System.Drawing.Point(0, 0);
            this.ColorBarBox.Name = "ColorBarBox";
            this.ColorBarBox.Size = new System.Drawing.Size(28, 407);
            this.ColorBarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ColorBarBox.TabIndex = 0;
            this.ColorBarBox.TabStop = false;
            // 
            // AxisZPanel
            // 
            this.AxisZPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AxisZPanel.Location = new System.Drawing.Point(28, 0);
            this.AxisZPanel.Name = "AxisZPanel";
            this.AxisZPanel.Size = new System.Drawing.Size(40, 407);
            this.AxisZPanel.TabIndex = 1;
            this.AxisZPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AxisZPanel_Paint);
            // 
            // FigurePanel
            // 
            this.FigurePanel.Controls.Add(this.FigureBox);
            this.FigurePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FigurePanel.Location = new System.Drawing.Point(0, 0);
            this.FigurePanel.Name = "FigurePanel";
            this.FigurePanel.Size = new System.Drawing.Size(511, 407);
            this.FigurePanel.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AxisYPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(618, 433);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.AxisXPanel);
            this.splitContainer2.Size = new System.Drawing.Size(583, 433);
            this.splitContainer2.SplitterDistance = 407;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.FigurePanel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ColorBarPanel);
            this.splitContainer3.Size = new System.Drawing.Size(583, 407);
            this.splitContainer3.SplitterDistance = 511;
            this.splitContainer3.TabIndex = 0;
            // 
            // PictureViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "PictureViewerControl";
            this.Size = new System.Drawing.Size(618, 433);
            ((System.ComponentModel.ISupportInitialize)(this.FigureBox)).EndInit();
            this.ColorBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColorBarBox)).EndInit();
            this.FigurePanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private InterpolationPictureBox FigureBox;
        private System.Windows.Forms.Panel AxisYPanel;
        private System.Windows.Forms.Panel AxisXPanel;
        private System.Windows.Forms.Panel ColorBarPanel;
        private System.Windows.Forms.Panel FigurePanel;
        private System.Windows.Forms.PictureBox ColorBarBox;
        private System.Windows.Forms.Panel AxisZPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
