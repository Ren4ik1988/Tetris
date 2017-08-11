using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class BackGraundImage
    {
        Image image;

        public Image Image { get => image; }

        public BackGraundImage()
        {
            image = Properties.Resources.BackImage;
        }
    }
}
