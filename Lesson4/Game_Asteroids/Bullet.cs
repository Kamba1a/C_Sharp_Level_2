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
        /// Отрисовка пули
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление координат нахождения пули по указанному смещению
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }
    }

}
