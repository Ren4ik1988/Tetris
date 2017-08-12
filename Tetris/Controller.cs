using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        Model model; // объект класса модел, используего для реализации всей логики приложения
        Screen screen; // объект пользовательского элемента управления, отвечающего за визуальное отображение игрового поля

        public MainForm()
        {
            model = new Model();
            screen = new Screen(model);
            InitializeComponent();
            this.Controls.Add(screen);
        }

        private void StartPause_Btn_Click(object sender, EventArgs e)
        {
            model.Random();
            screen.Invalidate();
        }
    }
}
