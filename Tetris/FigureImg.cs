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

        //эту строчку лучше сюда перенести:
        //public Image Img { get => image; }
        
        //члены класса и свойства лучше над конструктором, а функции под ним
        //при этом функции сначала должны идти public, и только потом private

        public FigureImg()
        {
            image = Properties.Resources.Block;
        }

        public Image Img { get => image; } 

    }
}
