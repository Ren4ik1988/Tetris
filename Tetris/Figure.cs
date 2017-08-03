using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tetris
{
    class Figure
    {
        FigureImg figureImg;
        public Image img;
        public int x, y;
        Random r;

        internal Figure()
        {
            figureImg = new FigureImg();
            r = new Random();
            x = figureImg.X + r.Next(0, 225);
            y = figureImg.Y;

            img = figureImg.Img;
        }

        public void Run()
        {
            Thread.Sleep(100);
            y++;
        }
    }
}
