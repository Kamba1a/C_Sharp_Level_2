using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "Корабль"
    /// </summary>
    class Ship : BaseObject
    {
        public static event Message MessageDie;

        /// <summary>
        /// Изображение объекта
        /// </summary>
        Image _img;

        /// <summary>
        /// Жизнь корабля
        /// </summary>
        public int HP { get; private set; } = 100;

        public Ship (Point pos, Point dir, Size size, string imgFilePath) : base(pos, dir, size)
        {
            _img = Image.FromFile(imgFilePath);
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Уменьшение жизни корабля
        /// </summary>
        /// <param name="n"></param>
        public void HPLow(int n)
        {
            Game.WriteLog?.Invoke($"Корабль получил урон на {n} HP");
            HP = HP - n;
        }

        /// <summary>
        /// Увеличение жизни корабля
        /// </summary>
        /// <param name="n"></param>
        public void HPHigh(int n)
        {
            if (HP >= 100) n = 0;
            HP = HP + n;
            Game.WriteLog?.Invoke($"Корабль восстановил {n} HP");
        }

        /// <summary>
        /// Обработка нажатия клавиши "Up"
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        /// <summary>
        /// Обработка нажатия клавиши "Down"
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        /// <summary>
        /// Уничтожение корабля
        /// </summary>
        public void Die()
        {
            Game.WriteLog?.Invoke("Корабль уничтожен");
            MessageDie?.Invoke();
        }
    }
}
