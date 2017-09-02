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
        Image mainImage, blockImage, lineImage, stallion1Image, stallion2Image, zFigureImage, sFigureImage, triangleImage;

        #region Свойства
        public Image BlockImage { get => blockImage; }
        public Image MainImage { get => mainImage;}
        public Image LineImage { get => lineImage; }
        public Image Stallion1Image { get => stallion1Image; }
        public Image Stallion2Image { get => stallion2Image; }
        public Image ZFigureImage { get => zFigureImage; }
        public Image SFigureImage { get => sFigureImage; }
        public Image TriangleImage { get => triangleImage; }
#endregion

        public Images()
        {
            mainImage = Properties.Resources.grid;
            blockImage = Properties.Resources.figure;
            lineImage = Properties.Resources.line;
            stallion1Image = Properties.Resources.stallion1;
            stallion2Image = Properties.Resources.stallion2;
            zFigureImage = Properties.Resources.ZFigure;
            sFigureImage = Properties.Resources.SFigure;
            triangleImage = Properties.Resources.triangle;
        }
    }
}
