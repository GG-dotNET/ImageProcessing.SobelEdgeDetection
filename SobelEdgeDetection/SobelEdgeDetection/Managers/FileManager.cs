using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SobelEdgeDetection.Interfaces;

namespace SobelEdgeDetection.Managers
{
    class FileManager : IOpenFile, ISaveFile
    {
        public string FilePath { get; set; }

        public void SaveFile(SaveFileDialog sfd)
        {
            sfd.Title = "Сохранить картинку как... ";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.Filter = "Image Files(*.JPG)|*.JPG|All files(*.*)|*.*";
            sfd.ShowHelp = true;
        }
    }
}
