using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Model
    {
        #region Constants: разрешение экрана в клетках

        public const int vertLength = 20;
        public const int gorizontLength = 10;

        #endregion
        
        Random random;

        BackGraundMatrix[,] mainScreen; // основной слой экрана, создается по типу матрицы обычного монитора, но вместо пикселей ячейки 

        public Model()
        {
            random = new Random();
            mainScreen = new BackGraundMatrix[vertLength, gorizontLength];
            FillMatrix();
        }

        internal BackGraundMatrix[,] MainScreen { get => mainScreen; set => mainScreen = value; }

        private void FillMatrix()
        {
            for (int i = 0; i < vertLength; i++)
                for (int j = 0; j < gorizontLength; j++)
                {
                    mainScreen[i, j] = new BackGraundMatrix();
                }
        }

        public void Random()
        {
            int j = random.Next(0,9); //локальная переменная используется для определения рандомной
                                      //позиции блока по горизонтальной координате
            mainScreen[0, j].PutImg();
            mainScreen[0, j].Image = mainScreen[0, j].Image;
        }
    }
}
