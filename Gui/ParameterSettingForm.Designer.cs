namespace HologramGenerator
{
    partial class ParameterSettingForm
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
            this.PSParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.PsDataGridView = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PsDataSet = new System.Data.DataSet();
            this.PsDataTable = new System.Data.DataTable();
            this.PsDtParameterColumn = new System.Data.DataColumn();
            this.PsDtLabelColumn = new System.Data.DataColumn();
            this.PsDtValueColumn = new System.Data.DataColumn();
            this.PsPresetPanel = new System.Windows.Forms.Panel();
            this.PsPresetComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PSCancelButton = new System.Windows.Forms.Button();
            this.PSSaveButton = new System.Windows.Forms.Button();
            this.PSParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsDataTable)).BeginInit();
            this.PsPresetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PSParametersGroupBox
            // 
            this.PSParametersGroupBox.AutoSize = true;
            this.PSParametersGroupBox.Controls.Add(this.PsDataGridView);
            this.PSParametersGroupBox.Controls.Add(this.PsPresetPanel);
            this.PSParametersGroupBox.Location = new System.Drawing.Point(2, 3);
            this.PSParametersGroupBox.Name = "PSParametersGroupBox";
            this.PSParametersGroupBox.Size = new System.Drawing.Size(220, 188);
            this.PSParametersGroupBox.TabIndex = 2;
            this.PSParametersGroupBox.TabStop = false;
            // 
            // PsDataGridView
            // 
            this.PsDataGridView.AllowUserToAddRows = false;
            this.PsDataGridView.AllowUserToDeleteRows = false;
            this.PsDataGridView.AutoGenerateColumns = false;
            this.PsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PsDataGridView.ColumnHeadersVisible = false;
            this.PsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn,
            this.labelDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.PsDataGridView.DataSource = this.PsBindingSource;
            this.PsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PsDataGridView.Location = new System.Drawing.Point(3, 42);
            this.PsDataGridView.Name = "PsDataGridView";
            this.PsDataGridView.RowHeadersVisible = false;
            this.PsDataGridView.RowTemplate.Height = 23;
            this.PsDataGridView.Size = new System.Drawing.Size(214, 143);
            this.PsDataGridView.TabIndex = 7;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Visible = false;
            this.keyDataGridViewTextBoxColumn.Width = 5;
            // 
            // labelDataGridViewTextBoxColumn
            // 
            this.labelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.labelDataGridViewTextBoxColumn.DataPropertyName = "Label";
            this.labelDataGridViewTextBoxColumn.HeaderText = "Label";
            this.labelDataGridViewTextBoxColumn.Name = "labelDataGridViewTextBoxColumn";
            this.labelDataGridViewTextBoxColumn.ReadOnly = true;
            this.labelDataGridViewTextBoxColumn.Width = 5;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // PsBindingSource
            // 
            this.PsBindingSource.DataMember = "Parameter";
            this.PsBindingSource.DataSource = this.PsDataSet;
            // 
            // PsDataSet
            // 
            this.PsDataSet.DataSetName = "PsDataSet";
            this.PsDataSet.Locale = new System.Globalization.CultureInfo("");
            this.PsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.PsDataTable});
            // 
            // PsDataTable
            // 
            this.PsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.PsDtParameterColumn,
            this.PsDtLabelColumn,
            this.PsDtValueColumn});
            this.PsDataTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Key"}, false)});
            this.PsDataTable.TableName = "Parameter";
            // 
            // PsDtParameterColumn
            // 
            this.PsDtParameterColumn.ColumnName = "Key";
            this.PsDtParameterColumn.ReadOnly = true;
            // 
            // PsDtLabelColumn
            // 
            this.PsDtLabelColumn.ColumnName = "Label";
            this.PsDtLabelColumn.ReadOnly = true;
            // 
            // PsDtValueColumn
            // 
            this.PsDtValueColumn.ColumnName = "Value";
            // 
            // PsPresetPanel
            // 
            this.PsPresetPanel.Controls.Add(this.PsPresetComboBox);
            this.PsPresetPanel.Controls.Add(this.label1);
            this.PsPresetPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PsPresetPanel.Location = new System.Drawing.Point(3, 17);
            this.PsPresetPanel.Name = "PsPresetPanel";
            this.PsPresetPanel.Size = new System.Drawing.Size(214, 25);
            this.PsPresetPanel.TabIndex = 10;
            // 
            // PsPresetComboBox
            // 
            this.PsPresetComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PsPresetComboBox.FormattingEnabled = true;
            this.PsPresetComboBox.Location = new System.Drawing.Point(48, 0);
            this.PsPresetComboBox.Name = "PsPresetComboBox";
            this.PsPresetComboBox.Size = new System.Drawing.Size(166, 23);
            this.PsPresetComboBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Presets";
            // 
            // PSCancelButton
            // 
            this.PSCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PSCancelButton.Location = new System.Drawing.Point(137, 197);
            this.PSCancelButton.Name = "PSCancelButton";
            this.PSCancelButton.Size = new System.Drawing.Size(75, 23);
            this.PSCancelButton.TabIndex = 8;
            this.PSCancelButton.Text = "&Close";
            this.PSCancelButton.UseVisualStyleBackColor = true;
            this.PSCancelButton.Click += new System.EventHandler(this.PSCancelButton_Click);
            // 
            // PSSaveButton
            // 
            this.PSSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PSSaveButton.Location = new System.Drawing.Point(56, 197);
            this.PSSaveButton.Name = "PSSaveButton";
            this.PSSaveButton.Size = new System.Drawing.Size(75, 23);
            this.PSSaveButton.TabIndex = 7;
            this.PSSaveButton.Text = "&Save";
            this.PSSaveButton.UseVisualStyleBackColor = true;
            this.PSSaveButton.Click += new System.EventHandler(this.PSSaveButton_Click);
            // 
            // ParameterSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 232);
            this.Controls.Add(this.PSSaveButton);
            this.Controls.Add(this.PSCancelButton);
            this.Controls.Add(this.PSParametersGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParameterSettingForm";
            this.ShowInTaskbar = false;
            this.Text = "Parameter Setting";
            this.Load += new System.EventHandler(this.ParameterSettingForm_Load);
            this.PSParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsDataTable)).EndInit();
            this.PsPresetPanel.ResumeLayout(false);
            this.PsPresetPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox PSParametersGroupBox;
        private System.Windows.Forms.Button PSCancelButton;
        private System.Windows.Forms.Button PSSaveButton;
        private System.Windows.Forms.DataGridView PsDataGridView;
        private System.Windows.Forms.BindingSource PsBindingSource;
        private System.Data.DataSet PsDataSet;
        private System.Data.DataTable PsDataTable;
        private System.Data.DataColumn PsDtParameterColumn;
        private System.Data.DataColumn PsDtLabelColumn;
        private System.Data.DataColumn PsDtValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel PsPresetPanel;
        private System.Windows.Forms.ComboBox PsPresetComboBox;
        private System.Windows.Forms.Label label1;
    }
}