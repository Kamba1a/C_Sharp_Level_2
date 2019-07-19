using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "пуля"
    /// </summary>
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление координат нахождения объекта по указанному смещению
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }

        /// <summary>
        /// Смещение пули на позицию носа корабля
        /// </summary>
        /// <param name="ship"></param>
        public void NewShot(Ship ship)
        {
            Pos.X = ship.GetPosition().X + ship.GetSize().Width;
            Pos.Y = ship.GetPosition().Y + ship.GetSize().Height/2;
        }
    }

}
