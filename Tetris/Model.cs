using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tetris
{
    class Model // вмещает в себя логику игры
    {
        private List<Figure> figure;
        public GameStatus GameStatus;
        int numberOfBlock;

        internal List<Figure> Figure { get => figure; }

        public Model() 
        {
            figure = new List<Figure>() { new Figure() };
            GameStatus = GameStatus.Paused;
        }

        public void Play(object obj)
        {
            if (GameStatus != GameStatus.StartNew)
            {
                if (Figure[numberOfBlock].Position.Y != 475)
                {

                    Figure[numberOfBlock].Run();
                }
                else
                {
                    numberOfBlock = figure.Count;
                    figure.Add(new Figure());
                    Figure[numberOfBlock].Run();
                }
            }
        }

        internal void Reset()
        {
            numberOfBlock = 0;
            figure.Clear();
            figure = new List<Figure>() { new Figure() };
        }
    }
}
