using System.Drawing;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class QudraPictureViewer : UserControl
    {
        #region Properties
        public string ImageLocation1
        {
            get
            {
                return pictureViewerControl1.FigureLocation;
            }
            set
            {
                pictureViewerControl1.FigureLocation = value;
            }
        }

        public Image Image1
        {
            get
            {
                return pictureViewerControl1.Figure;
            }
            set
            {
                pictureViewerControl1.Figure = value;
            }
        }

        public string ImageLocation2
        {
            get
            {
                return pictureViewerControl2.FigureLocation;
            }
            set
            {
                pictureViewerControl2.FigureLocation = value;
            }
        }

        public Image Image2
        {
            get
            {
                return pictureViewerControl2.Figure;
            }
            set
            {
                pictureViewerControl2.Figure = value;
            }
        }

        public string ImageLocation3
        {
            get
            {
                return pictureViewerControl3.FigureLocation;
            }
            set
            {
                pictureViewerControl3.FigureLocation = value;
            }
        }

        public Image Image3
        {
            get
            {
                return pictureViewerControl3.Figure;
            }
            set
            {
                pictureViewerControl3.Figure = value;
            }
        }

        public string ImageLocation4
        {
            get
            {
                return pictureViewerControl4.FigureLocation;
            }
            set
            {
                pictureViewerControl4.FigureLocation = value;
            }
        }

        public Image Image4
        {
            get
            {
                return pictureViewerControl4.Figure;
            }
            set
            {
                pictureViewerControl4.Figure = value;
            }
        }
#endregion

        public QudraPictureViewer()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = splitContainer1.Height / 2;
            splitContainer2.SplitterDistance = splitContainer2.Width / 2;
            splitContainer3.SplitterDistance = splitContainer3.Width / 2;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer3.SplitterDistance = splitContainer2.SplitterDistance;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer3.SplitterDistance;
        }
    }
}
