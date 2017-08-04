using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class FigureImg
    {
        Image img = Properties.Resources.Block; //так не плохо, но все же лучше поместить инициализацию в конструктор по умолчанию
        int x, y;

        public Image Img { get => img; } // img неплохо, но image читабельнее
        public int X { get => x; set => x = value; } // лучше уж тогда сделать автосвойство))
        public int Y { get => y; } // тут есть смысл оставить как сейчас, а вообще x и y лучше замени на Point и сделай для него два соответствующих свойства


    }
}
