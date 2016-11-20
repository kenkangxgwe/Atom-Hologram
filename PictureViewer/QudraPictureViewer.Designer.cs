namespace PictureViewer
{
    partial class QudraPictureViewer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureViewerControl1 = new PictureViewer.PictureViewerControl();
            this.pictureViewerControl2 = new PictureViewer.PictureViewerControl();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pictureViewerControl3 = new PictureViewer.PictureViewerControl();
            this.pictureViewerControl4 = new PictureViewer.PictureViewerControl();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(881, 510);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureViewerControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureViewerControl2);
            this.splitContainer2.Size = new System.Drawing.Size(881, 264);
            this.splitContainer2.SplitterDistance = 439;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // pictureViewerControl1
            // 
            this.pictureViewerControl1.AxesBorderWidth = 2;
            this.pictureViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureViewerControl1.Figure = null;
            this.pictureViewerControl1.FigureLocation = null;
            this.pictureViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.pictureViewerControl1.Name = "pictureViewerControl1";
            this.pictureViewerControl1.ShowColorBar = true;
            this.pictureViewerControl1.ShowXAxis = true;
            this.pictureViewerControl1.ShowYAxis = true;
            this.pictureViewerControl1.Size = new System.Drawing.Size(439, 264);
            this.pictureViewerControl1.TabIndex = 0;
            this.pictureViewerControl1.TickDashHeight = new System.Drawing.Size(0, 5);
            this.pictureViewerControl1.TickDashWidth = new System.Drawing.Size(5, 0);
            // 
            // pictureViewerControl2
            // 
            this.pictureViewerControl2.AxesBorderWidth = 2;
            this.pictureViewerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureViewerControl2.Figure = null;
            this.pictureViewerControl2.FigureLocation = null;
            this.pictureViewerControl2.Location = new System.Drawing.Point(0, 0);
            this.pictureViewerControl2.Name = "pictureViewerControl2";
            this.pictureViewerControl2.ShowColorBar = true;
            this.pictureViewerControl2.ShowXAxis = true;
            this.pictureViewerControl2.ShowYAxis = true;
            this.pictureViewerControl2.Size = new System.Drawing.Size(438, 264);
            this.pictureViewerControl2.TabIndex = 0;
            this.pictureViewerControl2.TickDashHeight = new System.Drawing.Size(0, 5);
            this.pictureViewerControl2.TickDashWidth = new System.Drawing.Size(5, 0);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pictureViewerControl3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pictureViewerControl4);
            this.splitContainer3.Size = new System.Drawing.Size(881, 242);
            this.splitContainer3.SplitterDistance = 439;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer3_SplitterMoved);
            // 
            // pictureViewerControl3
            // 
            this.pictureViewerControl3.AxesBorderWidth = 2;
            this.pictureViewerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureViewerControl3.Figure = null;
            this.pictureViewerControl3.FigureLocation = null;
            this.pictureViewerControl3.Location = new System.Drawing.Point(0, 0);
            this.pictureViewerControl3.Name = "pictureViewerControl3";
            this.pictureViewerControl3.ShowColorBar = true;
            this.pictureViewerControl3.ShowXAxis = true;
            this.pictureViewerControl3.ShowYAxis = true;
            this.pictureViewerControl3.Size = new System.Drawing.Size(439, 242);
            this.pictureViewerControl3.TabIndex = 0;
            this.pictureViewerControl3.TickDashHeight = new System.Drawing.Size(0, 5);
            this.pictureViewerControl3.TickDashWidth = new System.Drawing.Size(5, 0);
            // 
            // pictureViewerControl4
            // 
            this.pictureViewerControl4.AxesBorderWidth = 2;
            this.pictureViewerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureViewerControl4.Figure = null;
            this.pictureViewerControl4.FigureLocation = null;
            this.pictureViewerControl4.Location = new System.Drawing.Point(0, 0);
            this.pictureViewerControl4.Name = "pictureViewerControl4";
            this.pictureViewerControl4.ShowColorBar = true;
            this.pictureViewerControl4.ShowXAxis = true;
            this.pictureViewerControl4.ShowYAxis = true;
            this.pictureViewerControl4.Size = new System.Drawing.Size(438, 242);
            this.pictureViewerControl4.TabIndex = 0;
            this.pictureViewerControl4.TickDashHeight = new System.Drawing.Size(0, 5);
            this.pictureViewerControl4.TickDashWidth = new System.Drawing.Size(5, 0);
            // 
            // QudraPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "QudraPictureViewer";
            this.Size = new System.Drawing.Size(881, 510);
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

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private PictureViewerControl pictureViewerControl1;
        private PictureViewerControl pictureViewerControl2;
        private PictureViewerControl pictureViewerControl3;
        private PictureViewerControl pictureViewerControl4;
    }
}
