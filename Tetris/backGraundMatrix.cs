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
        BackGraundImage backGraundImage;
        Point position;
        Image image;

        public Point Position { get => position; set => position = value; }
        public Image Image { get => image; set => image = value; }

        public BackGraundMatrix()
        {
            backGraundImage = new BackGraundImage();
            image = backGraundImage.Image;
        }
    }
}
