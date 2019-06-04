using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "Звезда"
    /// </summary>
    class Star: BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y + Size.Height, Pos.X + Size.Width, Pos.Y);
        }
    }
}
