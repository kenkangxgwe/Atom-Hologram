using GlobalMethod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HologramGenerator
{
    public partial class RecompileForm : Form
    {
        public RecompileForm()
        {
            InitializeComponent();
        }

        private void RecompileForm_Load(object sender, EventArgs e)
        {
            CodeDataSet.ImportXml("MatlabCode");
            CodeLocationTextBox.Text = "DefaultMatlabCodeFolder".OriginPath();
            MccLocationTextBox.Text = "DefaultMccLocation".OriginPath();
        }

        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                CodeLocationTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void CodesLocationTextBox_TextChanged(object sender, EventArgs e)
        {
            string CodePath = CodeLocationTextBox.Text;
            foreach (DataGridViewRow Dr in CodeDataGridView.Rows)
            {
                if (File.Exists(CodePath + '\\' + Dr.Cells[0].Value.ToString()))
                {
                    Dr.Cells["Exist"].Value = "Exists.";
                    Dr.Cells["UseCustom"].Value = true;
                }
                else
                {
                    Dr.Cells["Exist"].Value = "Missing. Will apply default code.";
                    Dr.Cells["UseCustom"].Value = false;
                }
            }
        }

        private void DetailTextBox_Update(string LogText)
        {
            if (DetailTextBox.InvokeRequired)
            {
                Action<string> AppendText;
                AppendText = new Action<string>(DetailTextBox_Update);
                DetailTextBox.Invoke(AppendText, LogText);
            }
            else
            {
                DetailTextBox.AppendText(LogText + "\r\n");
            }
        }

        /// <summary>
        /// Generate the arguments and call Mcc
        /// mcc -W "dotnet:MatlabFunction,MatlabFunction,0.0,private"
        /// -T link:lib
        /// -d OutputFolder
        /// -v
        /// "class{ClassName1:MatlabFunction1.m, MatlabFunction2.m, MatlabFunction3.m}"
        /// "class{ClassName2:MatlabFunction4.m}" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecompileButton_Click(object sender, EventArgs e)
        {
            string CustomPath = CodeLocationTextBox.Text;
            string DefaultPath = "DefaultMatlabCodeFolder".OriginPath();
            string CodePath = CustomPath;
            string MccArgs = null;
            string MccArgsW = "-W \"dotnet:MatlabFunction,MatlabFunction,0.0,private\"";
            string MccArgsT = "-T link:lib";
            string MccArgsd = "-d " + "DefaultMatlabDllFolder".OriginPath().Wrap();
            string ClassCodeList = null;
            StringBuilder MccArgsv = new StringBuilder(" -v");
            Dictionary<string, StringBuilder> ClassList = new Dictionary<string, StringBuilder>();

            BrowserPanel.Enabled = false;
            ButtonsPanel.Enabled = false;

            foreach (DataGridViewRow Dr in CodeDataGridView.Rows)
            {
                if (!(bool)Dr.Cells["UseCustom"].Value)
                {
                    CodePath = DefaultPath;
                }

                if (ClassList.ContainsKey((string)Dr.Cells["Class"].Value))
                {
                    ClassList[(string)Dr.Cells["Class"].Value].Append(", " + CodePath + "\\" + (string)Dr.Cells["CodeName"].Value);
                }
                else
                {
                    ClassList.Add((string)Dr.Cells["Class"].Value, new StringBuilder(CodePath + "\\" + (string)Dr.Cells["CodeName"].Value));
                }
            }

            foreach (string ClassName in ClassList.Keys)
            {
                ClassCodeList = "class{" + ClassName + ":" + ClassList[ClassName].ToString() + "}";
                MccArgsv.Append(" " + ClassCodeList.Wrap());
            }

            MccArgs = MccArgsW + " " + MccArgsT + " " + MccArgsd + " " + MccArgsv.ToString();

            MatlabProcess MccProcess = new MatlabProcess(@"C:\Program Files\MATLAB\R2015b\bin\mcc.bat", MccArgs, DetailTextBox_Update, EnableAll);
            MccProcess.AsyncStart();
        }

        private void EnableAll()
        {
            if (InvokeRequired)
            {
                Action InvokeEnableAll = new Action(EnableAll);
                Invoke(InvokeEnableAll, null);
            }
            else
            {
                BrowserPanel.Enabled = true;
                ButtonsPanel.Enabled = true;
            }
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            CodeLocationTextBox.Text = "DefaultMatlabCodeFolder".OriginPath();
            MccLocationTextBox.Text = "DefaultMccLocation".OriginPath();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
