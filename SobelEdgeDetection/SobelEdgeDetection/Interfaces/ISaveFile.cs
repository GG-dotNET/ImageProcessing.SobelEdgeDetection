using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SobelEdgeDetection.Interfaces
{
    interface ISaveFile
    {
        SaveFileDialog sfd { get; set; }
        void SaveFile();
    }
}
