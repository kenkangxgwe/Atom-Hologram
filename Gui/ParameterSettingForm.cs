using GlobalMethod;
using System;
using System.Windows.Forms;

namespace HologramGenerator
{
    // TODO: Preset!
    public partial class ParameterSettingForm : Form
    {
        public ParameterSettingForm()
        {
            InitializeComponent();
        }

        private void PSCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PSSaveButton_Click(object sender, EventArgs e)
        {
            PsDataSet.ExportXml("Parameters");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ParameterSettingForm_Load(object sender, EventArgs e)
        {
            PsDataSet.ImportXml("Parameters");
        }
    }
}
