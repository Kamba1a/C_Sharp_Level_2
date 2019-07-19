using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "Далекая звезда"
    /// </summary>
    class FarStar: BaseObject
    {
        public FarStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
