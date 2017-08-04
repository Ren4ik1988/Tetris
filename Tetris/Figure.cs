using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Figure
    {
        #region private properties

        FigureImg figureImage;
        Random random;
        Image image;
        Point position;

        #endregion

        #region свойства доступа

        public Point Position { get => position; }
        public Image Image { get => image; }

        #endregion

        #region Constructor

        public Figure() 
        {
            figureImage = new FigureImg();

            image = figureImage.Img;
 
            InitializePos();
        }

        #endregion

        #region private functions

        private void InitializePos()
        {
            random = new Random();

            position.X = 25*random.Next(0,10);
            position.Y = 25;

            position = new Point(position.X, position.Y);
        }

        #endregion

        #region public functions

        public void Run()
        {
            position.Y += 25;
        }

        #endregion

    }
}
