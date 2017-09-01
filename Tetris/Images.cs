using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Images
    {
        Image mainImage, blockImage;

        public Image BlockImage { get => blockImage; }
        public Image MainImage { get => mainImage;}

        public Images()
        {
            mainImage = Properties.Resources.grid;
            blockImage = Properties.Resources.figure;
        }
    }
}
