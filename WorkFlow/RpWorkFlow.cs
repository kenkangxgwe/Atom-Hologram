using GlobalMethod;
using MathWorks.MATLAB.NET.Arrays;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class RpWorkFlow
    {
        private MatlabFunction.MatlabFunction Mf = null;
        public Action<string> Output{get;set;}
        public CancellationToken Token{get;set;}
        public string SavePath{get;set;}
        private DataSet PhaseRetrievalConfig = new DataSet();
        private DataTable Parameters = new DataTable();
        private StringBuilder MLLogSb = new StringBuilder();
        private MWStructArray MWParameter = new MWStructArray();

        /// <summary>
        /// Construct a RpWorkFlow.
        /// </summary>
        /// <param name="Output">A callback function for output</param>
        /// <param name="Token">A cancellation token</param>
        public RpWorkFlow(string SavePath, Action<string> Output, CancellationToken Token)
        {
            this.Output = Output;
            this.Token = Token;
            this.SavePath = SavePath;
        }

        public Task Run(Action<Task> NextStep)
        {
            return Task.Run(() =>
            {
                TextWriter StdOutTw = Console.Out;
                TextWriter StdErrTw = Console.Error;

                StringWriter MLLogSw = new StringWriter(MLLogSb);
                Console.SetOut(MLLogSw);
                Console.SetError(MLLogSw);

                PhaseRetrievalConfig.ImportXml(SavePath + "\\PhaseRetrievalConfig.xml");
                DataTable PhaseRetrievalData = PhaseRetrievalConfig.Tables["PhaseRetrievalData"];

                Listen(MLLogSb, Thread.CurrentThread);

                try
                {
                    Output("Initializing Matlab functions.");
                    Mf = new MatlabFunction.MatlabFunction();

                    ConstructMWParameter();

                    MergeByRows(PhaseRetrievalData, SavePath);

                    PhaseRetrivalIteration(PhaseRetrievalData, SavePath);
                    

                }
                // Reference: https://www.mgenware.com/blog/?p=397
                catch (OperationCanceledException)
                {
                    Output("Cancelled");
                    return;
                }
                // catch (System.FormatException)
                // {
                //     Output("Format in data table is wrong, please check again");
                //     return;
                // }
                finally
                {
                    Console.Out.Close();
                    Console.Error.Close();
                    Console.SetOut(StdOutTw);
                    Console.SetError(StdErrTw);
                    MLLogSw.Close();
                    MLLogSb.Clear();
                }
            },Token).ContinueWith(NextStep);
        }

        private async void Listen(StringBuilder MLLogSb, Thread ListenThread)
        {
            await Task.Run(() =>
            {
                while (ListenThread.IsAlive)
                {
                    if (MLLogSb.ToString() != null && MLLogSb.Length != 0)
                    {
                        Output(MLLogSb.ToString());
                        MLLogSb.Clear();
                    }
                    if (Token.IsCancellationRequested)
                    {
                        StreamWriter CancelWriter = new StreamWriter(SavePath + "\\Cancel.log");
                        CancelWriter.BaseStream.SetLength(0);
                        CancelWriter.WriteLine("Cancel");
                        CancelWriter.Dispose();
                    }
                    Thread.Sleep(2000);
                }

            }
            );
        }

        private void ConstructMWParameter()
        {
            DataSet Ds = new DataSet();
            Ds.ImportXml("Parameters");
            List<string> ParameterList = new List<string>();
            this.Parameters = Ds.Tables["Parameter"];
            DataTable PhaseRetrievalSettings = PhaseRetrievalConfig.Tables["Settings"];
            Dictionary<string, string> ParametersDict = new Dictionary<string, string>();
            ParametersDict = Parameters.ToDictionary();
            ParametersDict = ParametersDict.Concat(PhaseRetrievalSettings.ToDictionary()).ToDictionary(x=>x.Key,x=>x.Value);
            string[] ParametersKeyList = ParametersDict.Keys.ToArray<string>();

            MWParameter = new MWStructArray(1, 1, ParametersKeyList);

            foreach (string Key in ParametersKeyList)
            {
                MWParameter.SetField(Key, ParametersDict[Key].ToString());
            }
        }

        #region MergeByRows and Merge
        private void MergeByRows(DataTable Dt, string SavePath)
        {
            Output("Merging the data by row...");

            foreach (var Dr in Dt.Rows.Cast<DataRow>())
            {
                if (!Dr.IsMergedAt(SavePath))
                {
                    Merge(Dr, SavePath);
                    if (Dr.IsMergedAt(SavePath))
                    {
                        Dr["Merged"] = true;
                    }
                    Token.ThrowIfCancellationRequested();
                }
                else
                {
                    Output("Merging Skipped: The data at distance " + Dr["Distance"].ToString() + " has been merged.");
                }
            }

            Output("All data have been merged");
        }

        /// <summary>
        /// Generate arguments and call matlab function to merge row data
        /// </summary>
        /// <param name="Dr"></param>
        /// <param name="Dest"></param>
        /// <param name="Output"></param>
        private void Merge(DataRow Dr, string Dest)
        {
            Dest = Dest.OriginPath();

            string Path = Dr["Path"].ToString();
            string Filename = Dr["Filename"].ToString();
            string BgFilename = Dr["Bg_Filename"].ToString();
            int Width = Int32.Parse(MWParameter.GetField("width").ToString());
            int Height = Int32.Parse(MWParameter.GetField("height").ToString());
            int Distance = Int32.Parse(Dr["Distance"].ToString());
            string ExportName = Dr.GetName();
            string FgExportName = ExportName + '_' + "Foreground";
            string BgExportName = ExportName + '_' + "Background";
            int Start_No = Int32.Parse(Dr["Start_No"].ToString());
            int End_No = Int32.Parse(Dr["End_No"].ToString());
            int Bg_Start_No = Int32.Parse(Dr["Bg_Start_No"].ToString());
            int Bg_End_No = Int32.Parse(Dr["Bg_End_No"].ToString());

            Mf.MergeXlsData(Path, Filename, Dest, FgExportName, Width, Height, "whole", Start_No, End_No);
            // Output(MLLogSb.ToString());
            // MLLogSb.Clear();

            Mf.MergeXlsData(Path, BgFilename, Dest, BgExportName, Width, Height, "whole", Bg_Start_No,Bg_End_No);
            // Output(MLLogSb.ToString());
            // MLLogSb.Clear();

            Mf.SubtractBackground(Dest, ExportName);
            // Output(MLLogSb.ToString());
            // MLLogSb.Clear();

            File.Delete(Dest + '\\' + FgExportName + ".mat");
            File.Delete(Dest + '\\' + FgExportName + ".png");
            File.Delete(Dest + '\\' + BgExportName + ".mat");
            File.Delete(Dest + '\\' + BgExportName + ".png");
        }
        #endregion

        private void PhaseRetrivalIteration(DataTable Dt, string SavePath)
        {
            if (Dt.NumUse() < 4)
            {
                Output("Please select at least four images, "
                + "including a focal image, a reference image and at least two median images.");
                return;
            }

            if (Dt.NumType("Focal") != 1)
            {
                Output("Please select one and only one focal image.");
                return;
            }

            if (Dt.NumType("Reference") != 1)
            {
                Output("Please select one and only one reference image.");
                return;
            }

            string FocalName = null;
            int FocalDist = 0;
            List<String> MedianName = new List<string>();
            List<int> MedianDist = new List<int>();
            string ExportName = null;

            foreach (DataRow Dr in Dt.Rows)
            {
                if (Dr["Type"].ToString() == "Focal")
                {
                   FocalName = Dr.GetName(); 
                   FocalDist = int.Parse(Dr["Distance"].ToString());
                }

                if (Dr["Type"].ToString() == "Median")
                {
                    MedianName.Add(Dr.GetName());
                    MedianDist.Add(int.Parse(Dr["Distance"].ToString()));
                    ExportName = "RetrievedPhase";
                }

                if (Dr["Type"].ToString() == "Reference")
                {
                    continue;
                }
            }

            MWCharArray MWMedianName = new MWCharArray(MedianName.ToArray());
            MWNumericArray MWMedianDist = new MWNumericArray(1, MedianDist.Count, MedianDist.ToArray());

            StreamWriter CancelWriter = new StreamWriter(SavePath + "\\Cancel.log");
            CancelWriter.BaseStream.SetLength(0);
            CancelWriter.WriteLine("Continue");
            CancelWriter.Dispose();

            Mf.RetrieveReferencePhase(SavePath, ExportName, MWParameter, 10000, FocalName, FocalDist, MWMedianName, MWMedianDist);
            Token.ThrowIfCancellationRequested();
        }
    }
}
