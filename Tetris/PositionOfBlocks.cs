using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class PositionOfBlocks // класс отвечает за разметку координат для каждого элемента массива
    {
        static Point[,] position = new Point[Model.vertLength, Model.gorizontLength];
        static int xPos = 0;
        static int yPos = 0;
        static int sizeOfBlock = 25; // определяет размерность одного квадрата в пикселях

        static PositionOfBlocks()
        {
            for (int i = 0; i < Model.vertLength; i++)
            {
                for (int j = 0; j < Model.gorizontLength; j++)
                {
                    Position[i, j] = new Point(xPos, yPos);
                    xPos += sizeOfBlock;
                }
                xPos = 0;
                yPos += sizeOfBlock;
            }
        }

        public static Point[,] Position { get => position; }
    }
}
