using GlobalMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkFlow;

namespace HologramGenerator
{
    /// <summary>
    /// Retrieve Phase
    /// </summary>
    partial class MainForm
    {
        // Retrieve Phase
        //
        private string RpSavePath;
        private string RpNfsSavePath;
        private string RpEfsSavePath;
        private Dictionary<string,string> RpIsSettings;
        private CancellationTokenSource RpCts = new CancellationTokenSource();

        private void RpTabPage_Load(object sender, EventArgs e)
        {
            RpDataSet.Tables["Settings"].ImportXml("RpSettings");
            RpDpSplitContainer.Panel2Collapsed = true;
        }

        private void RpDpNfsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RpDpNfsPanel.Enabled = !RpDpNfsPanel.Enabled;
            RpDpEfsPanel.Enabled = !RpDpEfsPanel.Enabled;
            if (RpDpNfsRadioButton.Checked == true)
            {
                RpSavePath = RpNfsSavePath;
            }
            else
            {
                RpSavePath = RpEfsSavePath;
            }
        }

        private void RpDpFileListAddButton_Click(object sender, EventArgs e)
        {
            // GlobalConfigDataSet.Tables[].Rows.Add();
            try
            {
                RpDpBindingSource.AddNew();
            }
            catch (System.Data.NoNullAllowedException)
            {
                MessageBox.Show(
                    "Please input distance.",
                    "Distance is null",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

        }

        private void RpDpFileListDeleteButton_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewCell item in RpDpFileListDataGridView.SelectedCells)
            {
                // GlobalConfigDataSet.Tables[0].Rows.RemoveAt(item.RowIndex);
                if (item.RowIndex != -1)
                    RpDpBindingSource.RemoveAt(item.RowIndex);
            }
        }

        private void RpDpFileListContentTextBox_Refresh()
        {
            if (RpDpFileListDataGridView.SelectedCells.Count == 0)
            {
                RpDpFileListContentTextBox.Text = "(No Selections)";
                return;
            }

            DataGridViewCell FirstItem = RpDpFileListDataGridView.SelectedCells[0];
            foreach (DataGridViewCell Item in RpDpFileListDataGridView.SelectedCells)
            {
                if (Item.Value == null)
                {
                    RpDpFileListContentTextBox.Text = "Null";
                    return;
                }
                if (Item.Value.ToString() != FirstItem.Value.ToString())
                {
                    RpDpFileListContentTextBox.Text = "(Multi-Values)";
                    return;
                }
            }
            RpDpFileListContentTextBox.Text = FirstItem.Value.ToString();
        }

        private void RpPreview_Refresh()
        {
            if (RpDpFileListDataGridView.SelectedCells.Count == 0)
            {
                RpFigureViewer.Figure = null;
                return;
            }

            DataGridViewCell FirstItem = RpDpFileListDataGridView.SelectedCells[0];

            foreach (DataGridViewCell Item in RpDpFileListDataGridView.SelectedCells)
            {
                if (Item.RowIndex != FirstItem.RowIndex)
                {
                    RpFigureViewer.Figure = null;
                    return;
                }
            }

            DataRow SelectedRow = RpDataSet.Tables["PhaseRetrievalData"].Rows[FirstItem.RowIndex];
            if (SelectedRow.IsMergedAt(RpSavePath))
            {
                SelectedRow["Merged"] = true;
                RpFigureViewer.FigureLocation = RpEfsSavePath
                    + '\\' + "Dist_" + SelectedRow["Distance"] + "_Pos_" + "Whole" + '.' + "png";
            }
            else
            {
                SelectedRow["Merged"] = false;
                RpFigureViewer.Figure = null;
            }
        }

        private void RpDpFileListDataGridView_Click(object sender, EventArgs e)
        {
            if (RpDpEfsRadioButton.Checked == true)
            {
                RpPreview_Refresh();
            }
        }

        private void RpDpFileListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RpDpFileListContentTextBox_Refresh();
            if (RpDpEfsRadioButton.Checked == true)
            {
                RpPreview_Refresh();
            }
        }

        private void RpDpFileListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RpDpFileListContentTextBox_Refresh();
        }

        private void RpDpFileListContentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            if (RpDpFileListContentTextBox.Text == "(Multi-Values)")
                return;

            RpDpFileListContentTextBox.SelectAll();

            foreach (DataGridViewCell item in RpDpFileListDataGridView.SelectedCells)
            {
                item.Value = RpDpFileListContentTextBox.Text;
            }
        }

        private void RpDpFileListMergeButton_Click(object sender, EventArgs e)
        {
            if (saveFolderDialog.ShowDialog() == DialogResult.OK)
            {
                RpDataSet.ExportXml(saveFolderDialog.SelectedPath + "\\RpData.xml");
                // new MatlabServer (saveFolderDialog.SelectedPath);
            }
        }

        private void RpDpNfsSaveFolderButton_Click(object sender, EventArgs e)
        {
            if (saveFolderDialog.ShowDialog() == DialogResult.OK)
            {
                RpDpNfsSavePathTextBox.Text = saveFolderDialog.SelectedPath;
            }
        }

        private void RpDpNfsSavePathTextBox_TextChanged(object sender, EventArgs e)
        {
            RpNfsSavePath = RpDpNfsSavePathTextBox.Text;
            if (RpDpNfsRadioButton.Checked == true)
            {
                RpSavePath = RpNfsSavePath;
            }
        }

        private async void RpDpEfsBrowseButton_Click(object sender, EventArgs e)
        {
            if (openConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                RpDpEfsPathTextBox.Text = openConfigFileDialog.FileName;
                RpDataSet.ImportXml(RpDpEfsPathTextBox.Text);
                RpEfsSavePath = RpDpEfsPathTextBox.Text.Substring(0, RpDpEfsPathTextBox.Text.LastIndexOf('\\'));

                if (RpDpEfsRadioButton.Checked == true)
                {
                    RpSavePath = RpEfsSavePath;
                }
                foreach (DataRow item in RpDataSet.Tables["PhaseRetrievalData"].Rows)
                {
                    if (item.IsMergedAt(RpEfsSavePath))
                    {
                        item["Merged"] = true;
                    }
                    else
                    {
                        item["Merged"] = false;
                    }
                }
                RpIsSettings = RpDataSet.Tables["Settings"].ToDictionary();
                RpListView.FileListReload(RpSavePath, "RetrievedPhase*.png");
                await UpdateLastIteration(RpEfsSavePath + '\\' + RpIsSettings["filename"]);
            }
        }

        private Task UpdateLastIteration(string Dest)
        {
            return Task.Run(() =>
            {
                MatFile ExistMatFile = null;
                if (!File.Exists(Dest + ".mat"))
                {
                    RpIsSettings["lastiteration"] = "0";
                }
                else
                {
                    ExistMatFile = new MatFile(Dest);
                    RpIsSettings["lastiteration"] = ExistMatFile.LastIteration();
                }

                if (RpIsProgressTextBox.InvokeRequired)
                {
                    Action<string> ChangeText = ((x) => RpIsProgressTextBox.Text = x);
                    RpIsProgressTextBox.Invoke(ChangeText, "Start from iteration " + RpIsSettings["lastiteration"] + ".");
                }
            }
                );
        }

        private void RpDpEfsPathTextBox_TextChanged(object sender, EventArgs e)
        {
            RpEfsSavePath = RpDpEfsPathTextBox.Text;
        }

        private void RpPrevPanelButton_Click(object sender, EventArgs e)
        {

            RpDpSplitContainer.Panel1Collapsed = false;
            RpDpSplitContainer.Panel2Collapsed = true;
            RpPrevPanelButton.Enabled = false;
            RpNextPanelButton.Enabled = true;
        }

        private void RpNextPanelButton_Click(object sender, EventArgs e)
        {
            RpDpSplitContainer.Panel1Collapsed = true;
            RpDpSplitContainer.Panel2Collapsed = false;
            RpPrevPanelButton.Enabled = true;
            RpNextPanelButton.Enabled = false;
        }

        private void RpListView_Click(object sender, EventArgs e)
        {
            RpFigureViewer.FigureLocation = RpSavePath + "\\" + RpListView.SelectedItems[0].Text + ".png";
        }

        private void RpListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RpFigureViewer.FigureLocation = RpSavePath + "\\" + RpListView.SelectedItems[0].Text + ".png";
        }

        private async void RpRetrieveButton_Click(object sender, EventArgs e)
        {
            string SavePath;
            if (RpDpNfsRadioButton.Checked == true)
            {
                SavePath = RpDpNfsSavePathTextBox.Text;
                try
                {
                    if (Directory.GetFileSystemEntries(SavePath).Length > 0)
                    {
                        MessageBox.Show(
                            "The folder to store the outputs is not empty, please select an empty folder.",
                            "Folder not empty",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show(
                        "The path to store the outputs is illegal.",
                        "Path illegal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                SavePath = RpEfsSavePath;
            }

            RpRetrieveButton.Enabled = false;
            RpDpSavePathPanel.Enabled = false;
            RpIsDataGridView.ReadOnly = true;
            RpDpFileListDataGridView.ReadOnly = true;
            RpDpFileListControlPanel.Enabled = false;
            RpStopButton.Enabled = true;

            UpdateLastIteration(RpEfsSavePath + '\\' + RpIsSettings["filename"]);
            RpIsLastSavePointTextBox.Text = RpIsSettings["lastiteration"];
            RpIsSettings = RpDataSet.Tables["Settings"].ToDictionary();
            RpIsProgress_Update(int.Parse(RpIsLastSavePointTextBox.Text));
            RpDataSet.ExportXml(SavePath + "\\PhaseRetrievalConfig.xml");

            RpWorkFlow RetrievePhase = new RpWorkFlow(SavePath, OutputLog, RpCts.Token);
            await RetrievePhase.Run(Stop);
        }

        public void Stop(Task Tk)
        {
            if (InvokeRequired)
            {
                Action<Task> InvokeStop;
                InvokeStop = new Action<Task>(Stop);
                Invoke(InvokeStop, Tk);
            }
            else
            {
                RpStopButton.Enabled = false;
                RpRetrieveButton.Enabled = true;
                RpDpSavePathPanel.Enabled = true;
                RpIsDataGridView.ReadOnly = false;
                RpDpFileListDataGridView.ReadOnly = false;
                RpDpFileListControlPanel.Enabled = true;
            }
        }

        private void RpStopButton_Click(object sender, EventArgs e)
        {
            RpCts.Cancel();
            RpStopButton.Enabled = false;
        }

        /// <summary>
        /// A multi-process version of TextBox.Append().
        /// Reference: http://www.cnblogs.com/ymind/archive/2012/03/23/2415038.html
        /// </summary>
        /// <param name="LogText">Text that will display on DetailTextBox</param>
        private void OutputLog(string LogText)
        {
            if (InvokeRequired)
            {
                Action<string> AppendText;
                AppendText = new Action<string>(OutputLog);
                string[] LogTextLines = LogText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string LogLine in LogTextLines)
                    Invoke(AppendText, LogLine);
            }
            else
            {
                if (LogText.Length > 11 && LogText.Substring(0, 11) == "Iterations:")
                {
                    RpIsProgress_Update(int.Parse(LogText.Substring(11)));
                    return;
                }
                RpDetailsTextBox.AppendText('[' + DateTime.Now.ToString() + ']' + ' ');
                RpDetailsTextBox.AppendText(LogText);
                RpDetailsTextBox.AppendText("\r\n");
            }
        }

        /// <summary>
        /// Update Progress for each iteration.
        /// </summary>
        /// <param name="Iteration"></param>
        private void RpIsProgress_Update(int CurrentIteration)
        {
            int TotalIterations = int.Parse(RpIsSettings["iterations"]);
            int DisplayN = int.Parse(RpIsSettings["displayn"]);
            int LastSavePoint = int.Parse(RpIsLastSavePointTextBox.Text);
            int NextSavePoint = (CurrentIteration / DisplayN + 1) * DisplayN;

            if (NextSavePoint - LastSavePoint > DisplayN)
            {
                LastSavePoint = NextSavePoint - DisplayN;
                RpListView.FileListReload(RpSavePath, "RetrievedPhase*.png");
            }

            RpIsProgressBar.Value = (CurrentIteration - LastSavePoint) * 100 / DisplayN;
            RpIsCurrentIterationTextBox.Text = CurrentIteration.ToString() + "/" + TotalIterations.ToString();
            RpIsLastSavePointTextBox.Text = LastSavePoint.ToString();
            RpIsNextSavePointTextBox.Text = NextSavePoint.ToString();
        }
    }
}