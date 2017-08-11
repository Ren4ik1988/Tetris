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
        // тут лучше назвать "private members"
        #region private properties 

        FigureImg figureImage;
        Random random;
        Image image;
        Point position;

        #endregion

        //а тут как раз таки - "private properties" ))
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
            position.Y = -25;

            position = new Point(position.X, position.Y);

            //верхние строчки лучше перепиши так: [вариант 1]
            //int posX = 25 * random.Next(0, 10);
            //int posY = -25;
            //position = new Point(posX, posY);

            //а лучше вообще так: [вариант 2]
            //position = new Point(
            //    25 * random.Next(0, 10),
            //    -25);

            //а вот так еще лучше: )) [вариант 3]
            //position = new Point(25 * random.Next(0, 10), -25);
            //агрументы не сильно длинные, поэтому можно в одну строчку и читается норм [вариант 3]

            //если аргументы уже длинные, то лучше уже переноси их как в [вариант 2]

            //а если аргументов много, то лучше вынеси сначал их в переменные как в [вариант 1]
            //да, это лишние переменные, но зато читаться будет лучше код)) 
            //все равно компилятор по своему все оптимизирует в итоге
        }

        #endregion

        #region public functions

        public void Run()
        {
            if (position.Y != 475)
                position.Y += 25;
        }

        public void Reset()
        {
            InitializePos();
        }
        #endregion

    }
}
