namespace HologramGenerator
{
    partial class RecompileForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CodeLocationLabel = new System.Windows.Forms.Label();
            this.CodeLocationTextBox = new System.Windows.Forms.TextBox();
            this.FolderSelectButton = new System.Windows.Forms.Button();
            this.DetailTextBox = new System.Windows.Forms.TextBox();
            this.DetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CodeDataSet = new System.Data.DataSet();
            this.CodeTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.CodeDataGridView = new System.Windows.Forms.DataGridView();
            this.CodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseCustom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.RecompileButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.MccLocationLabel = new System.Windows.Forms.Label();
            this.MccLocationTextBox = new System.Windows.Forms.TextBox();
            this.MccSelectButton = new System.Windows.Forms.Button();
            this.SelectMccDialog = new System.Windows.Forms.OpenFileDialog();
            this.BrowserPanel = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.DetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeBindingSource)).BeginInit();
            this.BrowserPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeLocationLabel
            // 
            this.CodeLocationLabel.AutoSize = true;
            this.CodeLocationLabel.Location = new System.Drawing.Point(5, 2);
            this.CodeLocationLabel.Name = "CodeLocationLabel";
            this.CodeLocationLabel.Size = new System.Drawing.Size(293, 12);
            this.CodeLocationLabel.TabIndex = 0;
            this.CodeLocationLabel.Text = "Please specify the location of matlab codes (.m)";
            // 
            // CodeLocationTextBox
            // 
            this.CodeLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeLocationTextBox.Location = new System.Drawing.Point(7, 17);
            this.CodeLocationTextBox.Name = "CodeLocationTextBox";
            this.CodeLocationTextBox.Size = new System.Drawing.Size(363, 21);
            this.CodeLocationTextBox.TabIndex = 1;
            this.CodeLocationTextBox.TextChanged += new System.EventHandler(this.CodesLocationTextBox_TextChanged);
            // 
            // FolderSelectButton
            // 
            this.FolderSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderSelectButton.Location = new System.Drawing.Point(376, 15);
            this.FolderSelectButton.Name = "FolderSelectButton";
            this.FolderSelectButton.Size = new System.Drawing.Size(75, 23);
            this.FolderSelectButton.TabIndex = 2;
            this.FolderSelectButton.Text = "&Browser";
            this.FolderSelectButton.UseVisualStyleBackColor = true;
            this.FolderSelectButton.Click += new System.EventHandler(this.FolderSelectButton_Click);
            // 
            // DetailTextBox
            // 
            this.DetailTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailTextBox.Location = new System.Drawing.Point(3, 17);
            this.DetailTextBox.Multiline = true;
            this.DetailTextBox.Name = "DetailTextBox";
            this.DetailTextBox.ReadOnly = true;
            this.DetailTextBox.Size = new System.Drawing.Size(435, 176);
            this.DetailTextBox.TabIndex = 3;
            // 
            // DetailsGroupBox
            // 
            this.DetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsGroupBox.Controls.Add(this.DetailTextBox);
            this.DetailsGroupBox.Location = new System.Drawing.Point(33, 275);
            this.DetailsGroupBox.Name = "DetailsGroupBox";
            this.DetailsGroupBox.Size = new System.Drawing.Size(441, 196);
            this.DetailsGroupBox.TabIndex = 4;
            this.DetailsGroupBox.TabStop = false;
            this.DetailsGroupBox.Text = "Details";
            // 
            // CodeDataSet
            // 
            this.CodeDataSet.DataSetName = "CodeDataSet";
            this.CodeDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.CodeTable});
            // 
            // CodeTable
            // 
            this.CodeTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.CodeTable.TableName = "CodeTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Name";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Class";
            // 
            // CodeDataGridView
            // 
            this.CodeDataGridView.AllowUserToAddRows = false;
            this.CodeDataGridView.AllowUserToDeleteRows = false;
            this.CodeDataGridView.AllowUserToResizeColumns = false;
            this.CodeDataGridView.AllowUserToResizeRows = false;
            this.CodeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeDataGridView.AutoGenerateColumns = false;
            this.CodeDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CodeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CodeDataGridView.ColumnHeadersVisible = false;
            this.CodeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeName,
            this.Exist,
            this.Class,
            this.UseCustom});
            this.CodeDataGridView.DataSource = this.CodeBindingSource;
            this.CodeDataGridView.Location = new System.Drawing.Point(36, 109);
            this.CodeDataGridView.Name = "CodeDataGridView";
            this.CodeDataGridView.ReadOnly = true;
            this.CodeDataGridView.RowHeadersVisible = false;
            this.CodeDataGridView.RowTemplate.Height = 23;
            this.CodeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CodeDataGridView.Size = new System.Drawing.Size(435, 160);
            this.CodeDataGridView.TabIndex = 5;
            // 
            // CodeName
            // 
            this.CodeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CodeName.DataPropertyName = "Name";
            this.CodeName.HeaderText = "Name";
            this.CodeName.Name = "CodeName";
            this.CodeName.ReadOnly = true;
            this.CodeName.Width = 5;
            // 
            // Exist
            // 
            this.Exist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.NullValue = "Missing. Will apply default code.";
            this.Exist.DefaultCellStyle = dataGridViewCellStyle4;
            this.Exist.HeaderText = "Exist";
            this.Exist.Name = "Exist";
            this.Exist.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.DataPropertyName = "Class";
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            this.Class.Visible = false;
            // 
            // UseCustom
            // 
            this.UseCustom.HeaderText = "UseCustom";
            this.UseCustom.Name = "UseCustom";
            this.UseCustom.ReadOnly = true;
            this.UseCustom.Visible = false;
            // 
            // CodeBindingSource
            // 
            this.CodeBindingSource.DataMember = "CodeTable";
            this.CodeBindingSource.DataSource = this.CodeDataSet;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(373, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RecompileButton
            // 
            this.RecompileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RecompileButton.Location = new System.Drawing.Point(292, 3);
            this.RecompileButton.Name = "RecompileButton";
            this.RecompileButton.Size = new System.Drawing.Size(75, 23);
            this.RecompileButton.TabIndex = 6;
            this.RecompileButton.Text = "&Recompile";
            this.RecompileButton.UseVisualStyleBackColor = true;
            this.RecompileButton.Click += new System.EventHandler(this.RecompileButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultButton.Location = new System.Drawing.Point(211, 3);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.TabIndex = 6;
            this.DefaultButton.Text = "&Default";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // MccLocationLabel
            // 
            this.MccLocationLabel.AutoSize = true;
            this.MccLocationLabel.Location = new System.Drawing.Point(5, 41);
            this.MccLocationLabel.Name = "MccLocationLabel";
            this.MccLocationLabel.Size = new System.Drawing.Size(233, 12);
            this.MccLocationLabel.TabIndex = 0;
            this.MccLocationLabel.Text = "Please specify the location of mcc.bat";
            // 
            // MccLocationTextBox
            // 
            this.MccLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MccLocationTextBox.Location = new System.Drawing.Point(7, 56);
            this.MccLocationTextBox.Name = "MccLocationTextBox";
            this.MccLocationTextBox.Size = new System.Drawing.Size(363, 21);
            this.MccLocationTextBox.TabIndex = 1;
            this.MccLocationTextBox.TextChanged += new System.EventHandler(this.CodesLocationTextBox_TextChanged);
            // 
            // MccSelectButton
            // 
            this.MccSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MccSelectButton.Location = new System.Drawing.Point(376, 56);
            this.MccSelectButton.Name = "MccSelectButton";
            this.MccSelectButton.Size = new System.Drawing.Size(75, 23);
            this.MccSelectButton.TabIndex = 2;
            this.MccSelectButton.Text = "&Browser";
            this.MccSelectButton.UseVisualStyleBackColor = true;
            this.MccSelectButton.Click += new System.EventHandler(this.FolderSelectButton_Click);
            // 
            // SelectMccDialog
            // 
            this.SelectMccDialog.FileName = "SelectMccDialog";
            // 
            // BrowserPanel
            // 
            this.BrowserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowserPanel.Controls.Add(this.MccSelectButton);
            this.BrowserPanel.Controls.Add(this.FolderSelectButton);
            this.BrowserPanel.Controls.Add(this.MccLocationTextBox);
            this.BrowserPanel.Controls.Add(this.MccLocationLabel);
            this.BrowserPanel.Controls.Add(this.CodeLocationTextBox);
            this.BrowserPanel.Controls.Add(this.CodeLocationLabel);
            this.BrowserPanel.Location = new System.Drawing.Point(26, 17);
            this.BrowserPanel.Name = "BrowserPanel";
            this.BrowserPanel.Size = new System.Drawing.Size(462, 86);
            this.BrowserPanel.TabIndex = 7;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.DefaultButton);
            this.ButtonsPanel.Controls.Add(this.RecompileButton);
            this.ButtonsPanel.Controls.Add(this.CloseButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(26, 474);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(461, 34);
            this.ButtonsPanel.TabIndex = 8;
            // 
            // RecompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 512);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.BrowserPanel);
            this.Controls.Add(this.CodeDataGridView);
            this.Controls.Add(this.DetailsGroupBox);
            this.Name = "RecompileForm";
            this.Text = "Recompile Matlab Codes";
            this.Load += new System.EventHandler(this.RecompileForm_Load);
            this.DetailsGroupBox.ResumeLayout(false);
            this.DetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeBindingSource)).EndInit();
            this.BrowserPanel.ResumeLayout(false);
            this.BrowserPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CodeLocationLabel;
        private System.Windows.Forms.TextBox CodeLocationTextBox;
        private System.Windows.Forms.Button FolderSelectButton;
        private System.Windows.Forms.TextBox DetailTextBox;
        private System.Windows.Forms.GroupBox DetailsGroupBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Data.DataSet CodeDataSet;
        private System.Data.DataTable CodeTable;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.DataGridView CodeDataGridView;
        private System.Windows.Forms.BindingSource CodeBindingSource;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button RecompileButton;
        private System.Windows.Forms.Button DefaultButton;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseCustom;
        private System.Windows.Forms.Label MccLocationLabel;
        private System.Windows.Forms.TextBox MccLocationTextBox;
        private System.Windows.Forms.Button MccSelectButton;
        private System.Windows.Forms.OpenFileDialog SelectMccDialog;
        private System.Windows.Forms.Panel BrowserPanel;
        private System.Windows.Forms.Panel ButtonsPanel;
    }
}