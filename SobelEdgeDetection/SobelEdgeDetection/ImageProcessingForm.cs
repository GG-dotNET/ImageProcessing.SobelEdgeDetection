using SobelEdgeDetection.Interfaces;
using SobelEdgeDetection.Managers;
using System;
using System.Drawing;
using System.Windows.Forms;
using NLog;
using SobelEdgeDetection.Filters;

namespace SobelEdgeDetection
{
    public partial class ImageProcessingForm : Form
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private SaveFileDialog sfd;
        private IProcessingMethod operation;
        private Bitmap imageFirst;

        public ImageProcessingForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logger.Debug("Загружаем изображение из выбранного пути файла");

                    IOpenFile openFile = new FileManager();
                    openFile.FilePath = dOpen.FileName;
                    pictureBox1.Image = new Bitmap(dOpen.OpenFile());

                    _logger.Debug("Изображение успешно загруженно");
                }
                catch (Exception exception)
                {
                    _logger.Warn("Невозможно загрузить изображение");

                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            imageFirst = new Bitmap(pictureBox1.Image);
            operation = new Gray();
            operation = new Sobel();

            Bitmap imageLast = operation.Make(imageFirst);
            pictureBox2.Image = imageLast;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sfd = new SaveFileDialog();
            if (pictureBox2.Image != null)
            {
                ISaveFile saveFile = new FileManager();
                saveFile.SaveFile(sfd);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        _logger.Warn("Невозможно сохранить изображение");

                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
