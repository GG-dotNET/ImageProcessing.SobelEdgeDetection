using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SobelEdgeDetection.Interfaces
{
    interface ISobelModel
    {
        void SobelEdgeDetection(PictureBox pictureBox1, PictureBox pictureBox2);
    }
}
