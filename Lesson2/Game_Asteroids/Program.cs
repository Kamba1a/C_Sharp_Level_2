using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Ольга Назарова
Задания:
2.	Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
3.	Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
4.	Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
5.	* Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость или неверная позиция).
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
