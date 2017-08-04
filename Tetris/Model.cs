using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Model // вмещает в себя логику игры
    {
        // тут все вроде супер, за исключением что открытые члены лучше с большой буквы (закрытые с маленькой)
        public Figure figure;
        public GameStatus gameStatus;

        public Model() // сам класс приватный, а конструктор public (странно выглядит когда читаешь)
        {
            figure = new Figure();
            gameStatus = GameStatus.game_Paused;
        }

        // сама по себе задумка неплохая, посмотрим что будет дальше))
        public void Play()
        {
            while (gameStatus == GameStatus.game_Playing)
            {
                figure.Run();
            }
        }
    }
}
