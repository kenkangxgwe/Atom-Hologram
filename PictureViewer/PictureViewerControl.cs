using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class PictureViewerControl : UserControl
    {
        #region Private Members
        private Size _TickDashHeight = new Size(0,5);
        private Size _TickDashWidth = new Size(5,0);
        private Pen AxesLine = new Pen(Color.Black, 2);
        private Pen TickLable = new Pen(Color.Black, 2);
        private Point MouseLocationOriginal = new Point();
        private Point BoxLocationOriginal = new Point();
        private enum Axis { X, Y, Z };
        #endregion

        #region Properties
        public float AxesBorderWidth
        {
            get
            {
                return AxesLine.Width;
            }
            set
            {
                AxesLine.Width = value;
                TickLable.Width = value;
                Axes_Repaint();
            }
        }

        public Size TickDashHeight
        {
            get
            {
                return _TickDashHeight;
            }
            set
            {
                _TickDashHeight = value;
                Axes_Repaint();
            }
        }

        public Size TickDashWidth
        {
            get
            {
                return _TickDashWidth;
            }
            set
            {
                _TickDashWidth = value;
                Axes_Repaint();
            }
        }

        public string FigureLocation
        {
            get
            {
                return FigureBox.ImageLocation;
            }
            set
            {
                FigureBox.ImageLocation = value;
                Figure_Changed();
            }
        }

        public Image Figure
        {
            get
            {
                return FigureBox.Image;
            }
            set
            {
                FigureBox.Image = value;
                Figure_Changed();
            }
        }

        public bool ShowXAxis
        {
            get
            {
                return !splitContainer1.Panel1Collapsed;
            }
            set
            {
                splitContainer1.Panel1Collapsed = !value;
            }
        }

        public bool ShowYAxis
        {
            get
            {
                return !splitContainer2.Panel2Collapsed;
            }
            set
            {
                splitContainer2.Panel2Collapsed = !value;
            }
        }

        public bool ShowColorBar
        {
            get
            {
                return !splitContainer3.Panel2Collapsed;
            }
            set
            {
                splitContainer3.Panel2Collapsed = !value;
            }
        }
        #endregion

        // Constructors
        public PictureViewerControl()
        {
            InitializeComponent();
            SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            FigureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            FigureBox.MouseWheel += FigureBox_MouseWheel;
            ShowXAxis = true;
            ShowYAxis = true;
            ShowColorBar = true;
        }

        // Methods
        private void Figure_Changed()
        {
            this.Enabled = (FigureBox.Image != null || FigureBox.ImageLocation != null) ? true : false;
            FigureBox.Size = FigurePanel.Size;
            FigureBox.Location = new Point(0, 0);
            ColorBarPanel.Visible = true;
            Axes_Repaint();
            AxisZPanel.Refresh();
        }

        private void Axes_Repaint()
        {
            AxisYPanel.Refresh();
            AxisXPanel.Refresh();
        }

        private void FigureBox_Zoom(float ScaleDelta, Point Anchor)
        {
            // No zoom-in when reach only nine pixels
            if ((FigureBox.Image.Height * FigurePanel.Height / FigureBox.Height < 15
                || FigureBox.Image.Width * FigurePanel.Width / FigureBox.Width < 15)
                && ScaleDelta > 1)
                return;

            Rectangle BoxNew = new Rectangle();
        
            BoxNew.X = (int)Math.Round(Anchor.X * (1 - ScaleDelta) + FigureBox.Location.X * ScaleDelta);
            BoxNew.Y = (int)Math.Round(Anchor.Y * (1 - ScaleDelta) + FigureBox.Location.Y * ScaleDelta);
            BoxNew.Width = (int)Math.Round(FigureBox.Width * ScaleDelta);
            BoxNew.Height = (int)Math.Round(FigureBox.Height * ScaleDelta);

            Point ButtomRight = BoxNew.Location + BoxNew.Size;

            // No smaller than panel
            if (BoxNew.Width < FigurePanel.Width || BoxNew.Height < FigurePanel.Height)
            {
                BoxNew.Width = FigurePanel.Width;
                BoxNew.Height = FigurePanel.Height;
            }
            if (BoxNew.X > 0) BoxNew.X = 0;
            if (BoxNew.Y > 0) BoxNew.Y = 0;
            if (ButtomRight.X < FigurePanel.Width) BoxNew.X = FigurePanel.Width - BoxNew.Width;
            if (ButtomRight.Y < FigurePanel.Height) BoxNew.Y = FigurePanel.Height - BoxNew.Height;

            FigureBox.Size = BoxNew.Size;
            FigureBox.Location = BoxNew.Location;
        }

        private List<Tick> CalTickList (Axis specified)
        {
            double PixelRatio = 1;
            double PixelMin = 0;
            double PixelMax = 255;
            double PixelRange = 255;

            if (specified == Axis.Z)
            {
                string FigureComment = Encoding.ASCII.GetString(Image.FromFile(FigureBox.ImageLocation).GetPropertyItem(37510).Value);
                string[] ExtVal = FigureComment.Split(',');
                double MinVal = double.Parse(ExtVal[0]);
                double MaxVal = double.Parse(ExtVal[1]);
                PixelMin = MinVal;
                PixelMax = MaxVal;
                PixelRange = MaxVal - MinVal;
                PixelRatio = PixelRange / AxisZPanel.Height;
            }
            else
            {
                int BoxLocation = 0;
                int PanelSize = 0;

                if (specified == Axis.X)
                {
                    PixelRatio = (double)FigureBox.Image.Width / FigureBox.Width;
                    BoxLocation = FigureBox.Location.X;
                    PanelSize = FigurePanel.Width;
                }
                else if (specified == Axis.Y)
                {
                    PixelRatio = (double)FigureBox.Image.Height / FigureBox.Height;
                    BoxLocation = FigureBox.Location.Y;
                    PanelSize = FigurePanel.Height;
                }
                else return null;

                PixelMin = Math.Round((0 - BoxLocation) * PixelRatio);
                PixelMax = Math.Round((PanelSize - BoxLocation) * PixelRatio);
                PixelRange = PixelMax - PixelMin;
            }

            List<Tick> TickList = new List<Tick>();
            double PixelDimension = Math.Pow(10, Math.Floor(Math.Log10(PixelRange)));
            int MaxDigit = (int)Math.Floor(PixelRange / PixelDimension);
            double TickLength = PixelDimension;

            if(MaxDigit < 1.1)
            {
                TickLength = PixelDimension / 10;
            }
            else if (MaxDigit < 2.2)
            {
                TickLength = PixelDimension / 5;
            }
            else if(MaxDigit < 5.5)
            {
                TickLength = PixelDimension / 2;
            }

            for (int index = (int)Math.Ceiling(PixelMin / TickLength); index <= PixelMax / TickLength; index ++)
            {
                float PixelCor = (float)(index * TickLength); 
                float TickCor = (float)((PixelCor - PixelMin) / PixelRatio);
                switch (specified)
                {
                    case Axis.X:
                        TickList.Add(new Tick { Location = new PointF(TickCor, 0), TickLabel = PixelCor.ToString() });
                        break;
                    case Axis.Y:
                        TickList.Add(new Tick { Location = new PointF(AxisYPanel.Width, TickCor), TickLabel = PixelCor.ToString() });
                        break;
                    case Axis.Z:
                        TickList.Add(new Tick { Location = new PointF(0, AxisZPanel.Height - TickCor), TickLabel = PixelCor.ToString() });
                        break;
                    default:
                        return null;
                }
            }
            return TickList;
        }

        // Events
        private void AxisXPanel_Paint(object sender, PaintEventArgs e)
        {
            if (FigureBox.Image == null)
                return;
            Graphics Ruler = e.Graphics;
            float BorderOffset = (float)Math.Ceiling(AxesBorderWidth / 2.0);
            Ruler.DrawLine(AxesLine, 0, AxesBorderWidth / 2, FigurePanel.Width, AxesBorderWidth / 2);

            List<Tick> TickXList = CalTickList(Axis.X);
            foreach (Tick Tk in TickXList)
            {
                Ruler.DrawLine(AxesLine, Tk.Location, Tk.Location + TickDashHeight);
                Ruler.DrawString(Tk.TickLabel, this.Font, new SolidBrush(Color.Black), Tk.Location + TickDashHeight);
            }
        }

        private void AxisYPanel_Paint(object sender, PaintEventArgs e)
        {
            if (FigureBox.Image == null)
                return;
            Graphics Ruler = e.Graphics;
            float BorderOffset = (float)Math.Ceiling(AxesBorderWidth / 2.0);
            Ruler.DrawLine(AxesLine, AxisYPanel.Width - BorderOffset, 0, AxisYPanel.Width - BorderOffset, FigurePanel.Height);

            List<Tick> TickYList = CalTickList(Axis.Y);
            foreach (Tick Tk in TickYList)
            {
                Ruler.DrawLine(AxesLine, Tk.Location, Tk.Location - TickDashWidth);
                Ruler.DrawString(Tk.TickLabel, this.Font, new SolidBrush(Color.Black), 0, Tk.Location.Y);
            }
        }

        private void AxisZPanel_Paint(object sender, PaintEventArgs e)
        {
            if (FigureBox.Image == null )
                return;
            bool HasColorMap = false;
            foreach (int Id in Image.FromFile(FigureBox.ImageLocation).PropertyIdList)
            {
                if (Id == 37510)
                {
                    HasColorMap = true;
                    break;
                }
            }

            if (!HasColorMap)
            {
                ShowColorBar = false;
                return;
            }

            ShowColorBar = true;
            Graphics Ruler = e.Graphics;
            float BorderOffset = (float)Math.Ceiling(AxesBorderWidth / 2.0);
            Ruler.DrawLine(AxesLine, BorderOffset, 0, BorderOffset, AxisZPanel.Height);

            List<Tick> TickYList = CalTickList(Axis.Z);
            foreach (Tick Tk in TickYList)
            {
                Ruler.DrawLine(AxesLine, Tk.Location, Tk.Location + TickDashWidth);
                Ruler.DrawString(Tk.TickLabel, this.Font, new SolidBrush(Color.Black), TickDashWidth.Width, Tk.Location.Y);
            }
        }

        private void FigureBox_Paint(object sender, PaintEventArgs e)
        {
            Axes_Repaint();
        }

        private void FigureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MouseLocationOriginal = e.Location;
            BoxLocationOriginal = FigureBox.Location;
        }

        private void FigureBox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            FigureBox.Focus();
        }

        private void FigureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void FigureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point BoxLocationNew = FigureBox.Location;
                Point MouseOffset = e.Location - new Size(MouseLocationOriginal);
                BoxLocationNew.Offset(MouseOffset);
                Point BoxButtomRight = new Point(BoxLocationNew.X + FigureBox.Width, BoxLocationNew.Y + FigureBox.Height);
                if (BoxLocationNew.X > 0 || BoxLocationNew.Y > 0
                    || BoxButtomRight.X < FigurePanel.Width || BoxButtomRight.Y < FigurePanel.Height)
                    return;
                FigureBox.Location = BoxLocationNew;
            }
            if (e.Button == MouseButtons.Right)
            {
                float ScaleDelta = 1 + Math.Sign(MouseLocationOriginal.Y - e.Location.Y) * (float)0.05;
                FigureBox_Zoom(ScaleDelta, MouseLocationOriginal + new Size(BoxLocationOriginal));
            }
        }

        private void FigureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            float ScaleDelta = 1 + Math.Sign(e.Delta) * (float)0.2;
            FigureBox_Zoom(ScaleDelta, e.Location + new Size(FigureBox.Location));
        }
    }
}
