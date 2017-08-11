using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tetris
{
    partial class Screen : UserControl
    {
        public Model model;

        public Screen(Model model)
        {
            //мелочь, но лучше строчки местами поменять, хотя особых рекомендаций по этому поводу нет

            InitializeComponent();
            this.model = model;
        }

        void Draw(PaintEventArgs e)
        {
            foreach (Figure f in model.Figure)
                e.Graphics.DrawImage( //тут аргументы можно в одну строчку написать
                    f.Image,          //нет смысла по разным разносить (см. рекомендации в Figure.cs по этому поводу)
                    f.Position
                    );

            if (model.GameStatus != GameStatus.Playing) //эту проверку точно не надо перенести в начало функции
                return;                                 //цикл должен точно быть до проверки? 
                                                        //Если нет, то все условия где есть return лучше выносить в самый верх (по возможности) 
            Thread.Sleep(100);                          
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
