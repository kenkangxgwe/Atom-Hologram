using System.Windows.Forms;

namespace PictureViewer
{
    internal class InterpolationPictureBox : PictureBox
    {
        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode { get; set; }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(paintEventArgs);
        }
    }
}
