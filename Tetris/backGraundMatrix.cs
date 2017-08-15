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
        internal Images Images { get => images; set => images = value; }

        public BackGraundMatrix()
        {
            Images = new Images();
            Image = Images.MainImage;
        }


        public void PutImg()
        {
            if (Image != Images.BlockImage)
                Image = Images.BlockImage;
            else
                Image = Images.MainImage;
        }
    }
}
