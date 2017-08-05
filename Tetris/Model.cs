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
        public Figure Figure;
        public GameStatus GameStatus;

        public Model() 
        {
            Figure = new Figure();
            GameStatus = GameStatus.Paused;
        }

        public void Play(object obj)
        {
            Figure.Run();
        }
    }
}
