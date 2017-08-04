using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    //Тут вроде ничего особенного не заметил
    partial class Screen : UserControl
    {
        public Model model;

        public Screen(Model model)
        {
            // У меня прога не компилируется из-за это строчки
            // пишет что функция не найдена в существующем контексте
            InitializeComponent(); 
            this.model = model;

            // вообще старайся чтобы когда твои коллеги получают твои коммиты себе проект компилировался
            // либо прям в коммите указывай в самом начале что версия не компилируемая, это сэкономит много времени товарищам))
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.figure.img, new Point(model.figure.x, model.figure.y));

            //для красоты когда передаваемые параметры длинные можно написать так (читабельнее так, но не обязательно, это уж вопросы почерка):
            //e.Graphics.DrawImage(
            //    model.figure.img, 
            //    new Point(model.figure.x, model.figure.y)
            //);
            
            Invalidate();
        }
    }
}
