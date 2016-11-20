using System;
using System.Diagnostics;

namespace HologramGenerator
{
    // Class handling Matlab Functions
    public class MatlabProcess : Process
    {
        public Action<string> Output { get; set; }
        public Action Finish { get; set; }

        public MatlabProcess (string FuncName, string Args, Action<string> Output, Action Finish) {
            
            this.StartInfo.FileName = FuncName;
            this.StartInfo.Arguments = Args;
            this.Output = Output;
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardOutput = true;
            this.StartInfo.RedirectStandardError = true;
            this.EnableRaisingEvents = true;
            this.Finish = Finish;
        }

        public void AsyncStart() {
            this.Start();
            this.OutputDataReceived += MatlabProcess_OutputDataReceived;
            this.ErrorDataReceived += MatlabProcess_OutputDataReceived;
            this.BeginOutputReadLine();
            this.BeginErrorReadLine();
            this.Exited += MatlabProcess_Exited;
        }

        void MatlabProcess_Exited(object sender, EventArgs e)
        {
            Finish();
        }

        void MatlabProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            Output(e.Data);
        }
    }
}
