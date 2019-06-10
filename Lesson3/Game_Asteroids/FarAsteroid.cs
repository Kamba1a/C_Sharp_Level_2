using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "Далекий астероид"
    /// </summary>
    class FarAsteroid : BaseObject
    {
        public FarAsteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
