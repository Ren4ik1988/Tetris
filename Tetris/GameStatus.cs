using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    enum GameStatus
    {
        game_Playing, game_Paused, game_StartNew
    }

    //Предлагаю описать перечисление так:
    //enum GameStatus
    //{
    //    StartNew, - первое значение потому, что оно начальное (игра изначально скорее всего не запущена)
    //    Playing, 
    //    Paused
    //}
    //приставку game убрал, иначе странно получается - GameStatus.game_Playing. Так получше - GameStatus.Playing
    //вообще количество статусов правильно определил. Может еще придется ввести четвертый - Stop (для описания состояния 
    //в котором игра завершена либо с успехом либо нет и ожидается переход к StartNew). Но пока не уверен
    
}
