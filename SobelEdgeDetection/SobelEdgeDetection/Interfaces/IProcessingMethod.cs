using System.Drawing;

namespace SobelEdgeDetection.Interfaces
{
    interface IProcessingMethod
    {
        Bitmap Make(Bitmap image);
    }
}
