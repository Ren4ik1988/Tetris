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

        # region Установка изображений, используемых для построения фигур

        public void PutMainImg()
        {
            Image = Images.MainImage;
        }

        public void PutFigureImg()
        {
            Image = Images.BlockImage; ;
        }

        public void PutLineImg()
        {
            Image = Images.LineImage;
        }

        public void PutStallion1Img()
        {
            Image = Images.Stallion1Image;
        }

        public void PutStallion2Img()
        {
            Image = Images.Stallion2Image;
        }

        public void PutZFigureImg()
        {
            Image = Images.ZFigureImage;
        }

        public void PutSFigureImg()
        {
            Image = Images.SFigureImage;
        }

        public void PutTriangleImg()
        {
            Image = Images.TriangleImage;
        }

        #endregion
    }
}
