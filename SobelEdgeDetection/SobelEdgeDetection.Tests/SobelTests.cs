using System;
using System.Windows.Forms;
using Xunit;
using System.Drawing;

namespace SobelEdgeDetection.Tests
{
    public class SobelTests
    {
        [Fact]
        public void SobelEdgeDetection()
        {
            // arange
            PictureBox pictureBox1 = new PictureBox();
            PictureBox pictureBox2 = new PictureBox();

            // act
            Sobel sobel = new Sobel();
            

            // assert
            Assert.Throws<InvalidOperationException>(
                () => sobel.SobelEdgeDetection(pictureBox1, pictureBox2)
            );
        }
    }
}
