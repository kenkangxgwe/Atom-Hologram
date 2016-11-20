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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
            this.Load += new System.EventHandler(this.RpTabPage_Load);
        }
    }
}
