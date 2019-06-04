using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Ольга Назарова
Задание:
1.	Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
2.	* Заменить кружочки картинками, используя метод DrawImage.
*/

namespace Game_Asteroids
{
    static class Program
    {
        //[STAThread]
        static void Main()
        {
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
