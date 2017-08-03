using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class FigureImg
    {
        Image img = Properties.Resources.Block;
        int x, y;

        public Image Img { get => img; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; }
    }
}
