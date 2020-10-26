using NLog;
using SobelEdgeDetection.Interfaces;
using System;
using System.Drawing;

namespace SobelEdgeDetection.Filters
{
    public class Gray : IProcessingMethod
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public Bitmap Make(Bitmap image)
        {
            _logger.Debug("Преобразование RGB канала " + image);

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixel = image.GetPixel(j, i);
                    int differentValue = (pixel.R + pixel.G + pixel.B) / 3;
                    Color color;
                    color = Color.FromArgb(differentValue, differentValue, differentValue);
                    image.SetPixel(j, i, color);
                }

            }
            _logger.Debug("Изображение успешно преобразовано. Затраченное время (мс): " + new TimeSpan(0, 0, 0, 0, 20).Milliseconds);

            return image;
        }
    }
}
