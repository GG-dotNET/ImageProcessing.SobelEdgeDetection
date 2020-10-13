using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SobelEdgeDetection.Interfaces;
using SobelEdgeDetection.Repository;

namespace SobelEdgeDetection
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

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
            ISobelModel sobel = new Sobel();
            sobel.SobelEdgeDetection(pictureBox1, pictureBox2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                ISaveFile saveFile = new FileManager();
                saveFile.SaveFile();

                if (saveFile.sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox2.Image.Save(saveFile.sfd.FileName);
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
