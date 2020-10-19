using System.Windows.Forms;

namespace SobelEdgeDetection.Interfaces
{
    interface IProcessingMethod
    {
        void SobelEdgeDetection(PictureBox pictureBox1, PictureBox pictureBox2);
    }
}
