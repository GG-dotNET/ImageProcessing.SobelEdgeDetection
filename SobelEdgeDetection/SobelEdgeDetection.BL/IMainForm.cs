using System;
using System.Collections.Generic;
using System.Text;

namespace SobelEdgeDetection.BL
{
    public interface IMainForm
    {
        string FilePath { get; }
        event EventHandler FileOpenClick;
    }
}
