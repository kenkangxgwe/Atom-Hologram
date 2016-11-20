using System;

namespace HologramGenerator
{
    partial class MainForm
    {
        // Menu Bar
        //
        // File
        // 
        private void MenuBarFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Option
        // 
        private void MenuBarParameterSetting_Click(object sender, EventArgs e)
        {
            ParameterSettingForm parametersettingform = new ParameterSettingForm();
            parametersettingform.ShowDialog();

        }

        private void MenuBarRecompile_Click(object sender, EventArgs e)
        {
            RecompileForm recompileform = new RecompileForm();
            recompileform.ShowDialog();
        }

        private void MenuBarLocalizationEnglish_Click(object sender, EventArgs e)
        {

        }

        // Help
        //
        private void MenuBarHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.ShowDialog();
        }
    }
}
