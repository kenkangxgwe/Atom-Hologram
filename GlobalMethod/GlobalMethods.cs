using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace GlobalMethod
{
    /// <summary>
    /// Parser for Specific Destinations
    /// </summary>
    public static class GlobalMethod
    {

        /// <summary>
        /// Convert a key-value datatable to a dictionary.
        /// </summary>
        /// <param name="Dt">A datatable which has both "Key" and "Value" Columns.</param>
        /// <returns>A dictionary according to the data from datatable.</returns>
        public static Dictionary<string, string> ToDictionary(this DataTable Dt)
        {
            Dictionary<string, string> Dic = new Dictionary<string,string>();
            if (!Dt.Columns.Contains("Key") || !Dt.Columns.Contains("Value"))
            {
                return Dic;
            }
            foreach (DataRow Dr in Dt.Rows)
            {
                Dic.Add(Dr["Key"].ToString(), Dr["Value"].ToString());
            }
            return Dic;
        }

        /// <summary>
        /// Get the original path of a keyword, or just return itself when it is an exact path.
        /// (No backslash at the end of a folder)
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string OriginPath (this string Path)
        {
            switch(Path) {
                case "Program":
                    return Directory.GetCurrentDirectory();

                case "ProgramConfig":
                    return "Program".OriginPath() + "\\Config";

                case "Parameters":
                    return "ProgramConfig".OriginPath() + "\\Parameters.xml";

                case "ConfigPath":
                    return "ProgramConfig".OriginPath() + "\\globalconfig.xml";

                case "MatlabCode":
                    return "DefaultMatlabCodeFolder".OriginPath() + "\\CodeList.xml";

                case "DefaultMatlabCodeFolder":
                    return Properties.Settings.Default.MatlabCodePath;

                case "DefaultMatlabDllFolder":
                    return "Program".OriginPath() + "\\MatlabDlls\\Default";

                case "ParametersTable":
                    return "ProgramConfig".OriginPath() + "\\parametersTable.xml";

                case "RpSettings":
                    return "ProgramConfig".OriginPath() + "\\RpSettings.xml";

                case "DefaultMccLocation":
                    return Properties.Settings.Default.MccPath;

                default:
                    {
                        if (Path[Path.Length - 1] == '\\')
                        {
                            return Path.Substring(0,Path.Length-1);
                        } else {
                            return Path;
                        }
                    }
            }
        }

        /// <summary>
        /// Return a string that has quotes on both sides if there is any white space in the string.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string Wrap(this string Path)
        {
            if (Path.IndexOf(' ') >=0 )
            {
                return "\"" + Path + "\"";
            }
            return Path;
        }

        // Global extend method to implement XML I/O
        
        /// <summary>
        /// Export a DataTable to a .xml file.
        /// </summary>
        /// <param name="Dt"></param>
        /// <param name="Dest"></param>
        public static void ExportXml (this DataTable Dt, string Dest)
        {
            XmlWriterSettings XmlSettings = new XmlWriterSettings();
            XmlSettings.Encoding = System.Text.Encoding.UTF8;
            XmlSettings.Indent = true;
            XmlSettings.IndentChars = "\t";
            XmlSettings.NewLineChars = "\r\n";
            XmlWriter Xw = XmlWriter.Create(Dest.OriginPath(), XmlSettings);
            Dt.WriteXml(Xw);
            Xw.Close();
        }
        
        /// <summary>
        /// Export a DataSet to a .xml file.
        /// </summary>
        /// <param name="Ds"></param>
        /// <param name="Dest"></param>
        public static void ExportXml (this DataSet Ds, string Dest)
        {
            XmlWriterSettings XmlSettings = new XmlWriterSettings();
            XmlSettings.Encoding = System.Text.Encoding.UTF8;
            XmlSettings.Indent = true;
            XmlSettings.IndentChars = "\t";
            XmlSettings.NewLineChars = "\r\n";
            XmlWriter Xw = XmlWriter.Create(Dest.OriginPath(), XmlSettings);
            Ds.WriteXml(Xw);
            Xw.Close();
        }

        /// <summary>

        /// Import a .xml file to a DataTable.
        /// </summary>
        /// <param name="Dt"></param>
        /// <param name="Dest"></param>
        public static void ImportXml (this DataTable Dt, string Dest)
        {
            Dt.Rows.Clear();
            XmlReader Xw = XmlReader.Create(Dest.OriginPath());
            Dt.ReadXml(Xw);
            Xw.Close();
        }

        /// <summary>
        /// Import a .xml file to a DataSet.
        /// </summary>
        /// <param name="Ds"></param>
        /// <param name="Dest"></param>
        public static void ImportXml (this DataSet Ds, string Dest)
        {
            foreach(DataTable Dt in Ds.Tables) {
                Dt.Rows.Clear();
            }
            XmlReader Xw = XmlReader.Create(Dest.OriginPath());
            Ds.ReadXml(Xw);
            Xw.Close();
        }

        public static void FileListReload(this ListView Lv, string Dest, string Regex)
        {
            Lv.Items.Clear();

            if (!Directory.Exists(Dest.OriginPath()))
            {
                return;
            }

            string[] FileNamesWithPath = null;
            FileNamesWithPath = Directory.GetFiles(Dest.OriginPath(), Regex);
            foreach (string File in FileNamesWithPath)
            {
                Lv.Items.Add(Path.GetFileNameWithoutExtension(File));
            }
        }

        public static int NumUse(this DataTable Dt) {
            int UseCount = 0;
            foreach (var Dr in Dt.Rows.Cast<DataRow>())
            {
                if (Boolean.Parse(Dr["Use"].ToString()))
                    UseCount++;
            }
            return UseCount;
        }

        public static int NumType(this DataTable Dt, string Type) {
            int TypeCount = 0;
            foreach (var Dr in Dt.Rows.Cast<DataRow>())
            {
                if (Dr["Type"].ToString() == Type)
                    TypeCount++;
            }
            return TypeCount;
        }

        public static string GetName(this DataRow Dr)
        {
            return "Dist_" + Dr["Distance"] + "_Pos_" + "Whole";
        }

        /// <summary>
        /// Return a bool value whether the datarow has been merged.
        /// </summary>
        /// <param name="Dr"></param>
        /// <param name="Dest"></param>
        /// <returns></returns>
        public static bool IsMergedAt(this DataRow Dr, string Dest)
        {
            try
            {
                Dest = Dest.OriginPath();
            }
            catch
            {
                return false;
            }
            string Filename = Dest + "\\" + Dr.GetName();
            string [] Extnames = {"mat", "png"};
            foreach (string Extname in Extnames)
            {
                if (File.Exists(Filename + '.' + Extname) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
