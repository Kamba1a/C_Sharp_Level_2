using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Ольга Назарова

Задание 1.	Добавить в программу коллекцию астероидов. Как только она заканчивается (все астероиды сбиты), формируется новая коллекция, в которой на один астероид больше.
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
