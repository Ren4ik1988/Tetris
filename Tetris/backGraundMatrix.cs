using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class BackGraundMatrix
    {
        Images images;
        Image image;

        public Image Image { get => image; set => image = value; }

        public BackGraundMatrix()
        {
            images = new Images();
            Image = images.MainImage;
        }


        public void PutImg()
        {
            if (Image != images.BlockImage)
                Image = images.BlockImage;
            else
                Image = images.MainImage;
        }
    }
}
