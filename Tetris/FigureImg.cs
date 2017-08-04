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
        Image image; 
        
        public FigureImg()
        {
            image = Properties.Resources.Block;
        }

        public Image Img { get => image; } 

    }
}
