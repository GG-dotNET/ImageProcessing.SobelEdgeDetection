using SobelEdgeDetection.Interfaces;
using SobelEdgeDetection.Managers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SobelEdgeDetection
{
    public partial class ImageProcessingForm : Form
    {
        public ImageProcessingForm()
        {
            InitializeComponent();
        }

        SaveFileDialog sfd = new SaveFileDialog();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IOpenFile openFile = new FileManager();
                    openFile.FilePath = dOpen.FileName;
                    pictureBox1.Image = new Bitmap(dOpen.OpenFile());
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IProcessingMethod sobel = new Sobel();
            sobel.SobelEdgeDetection(pictureBox1, pictureBox2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
