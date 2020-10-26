using SobelEdgeDetection.Interfaces;
using System.Windows.Forms;
using NLog;

namespace SobelEdgeDetection.Managers
{
    class FileManager : IOpenFile, ISaveFile
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string FilePath { get; set; }

        public void SaveFile(SaveFileDialog sfd)
        {
            _logger.Debug("Сохраняем полученное изображение");

            sfd.Title = "Сохранить картинку как... ";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.Filter = "Image Files(*.JPG)|*.JPG|All files(*.*)|*.*";
            sfd.ShowHelp = true;

            _logger.Debug("Изображение успешно сохранено");
        }
    }
}
