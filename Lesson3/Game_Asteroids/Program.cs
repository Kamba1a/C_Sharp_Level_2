using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Ольга Назарова
Задания:
1.	Добавить космический корабль, как описано в уроке.
2.	Доработать игру «Астероиды»:
    a.	Добавить ведение журнала в консоль с помощью делегатов;
    b.	* добавить это и в файл.
3.	Разработать аптечки, которые добавляют энергию.
4.	Добавить подсчет очков за сбитые астероиды.
5.	* Добавить в пример Lesson3 обобщенный делегат.
*/

namespace Game_Asteroids
{
    static class Program
    {
        //[STAThread]
        static void Main()
        {
            //Form form = new Form
            //{
            //    Width = Screen.PrimaryScreen.Bounds.Width,
            //    Height = Screen.PrimaryScreen.Bounds.Height
            //};

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;

            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
