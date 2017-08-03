using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Model // вмещает в себя логику игры
    {
        public Figure figure;
        public GameStatus gameStatus;

        public Model()
        {
            figure = new Figure();
            gameStatus = GameStatus.game_Paused;
        }

        public void Play()
        {
            while (gameStatus == GameStatus.game_Playing)
            {
                figure.Run();
            }
        }
    }
}
