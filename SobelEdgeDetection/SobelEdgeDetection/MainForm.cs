using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SobelEdgeDetection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string filePath;
        
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = dOpen.FileName;
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
            Sobel sobel = new Sobel();
            sobel.SobelEdgeDetection(pictureBox1, pictureBox2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как... ";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.JPG)|*.JPG|All files(*.*)|*.*";
                sfd.ShowHelp = true;

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
