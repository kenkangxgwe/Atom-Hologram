using GlobalMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HologramGenerator
{
    partial class MainForm
    {
        private void ChWfEflRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChWfEflPanel.Enabled = !ChWfEflPanel.Enabled;
        }

        private void ChWfEflBrowseButton_Click(object sender, EventArgs e)
        {
            if (openConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                ChWfEflPathTextBox.Text = openConfigFileDialog.FileName;
            }
        }

        private void ChHrdAddButton_Click(object sender, EventArgs e)
        {
            if (openDataFilesDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void ChHrdDeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in ChHrdDataGridView.SelectedRows)
            {
                ChHrdDataGridView.Rows.RemoveAt(item.Index);
            }
        }

        private void ChHrdMergeButton_Click(object sender, EventArgs e)
        {
            if (saveFolderDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void ChConstructButton_Click(object sender, EventArgs e)
        {
            ChStopButton.Enabled = true;
            ChConstructButton.Enabled = false;
        }

        private void ChStopButton_Click(object sender, EventArgs e)
        {
            ChStopButton.Enabled = false;
            ChConstructButton.Enabled = true;
        }

        private void ChSavePathBrowseButton_Click(object sender, EventArgs e)
        {
            if (saveFolderDialog.ShowDialog() == DialogResult.OK)
            {
                ChSavePathTextBox.Text = saveFolderDialog.SelectedPath;
            }
        }
    }
}
