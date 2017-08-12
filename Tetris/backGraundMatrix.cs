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
        Image image;

        public Image Image { get => image; }

        public BackGraundMatrix()
        {
            image = Properties.Resources.BackImage;
        }

    }
}
