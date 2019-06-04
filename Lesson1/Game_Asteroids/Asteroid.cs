using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "астероид"
    /// </summary>
    class Asteroid: BaseObject
    {
        /// <summary>
        /// Изображение объекта
        /// </summary>
        Image _img;

        public Asteroid(Point pos, Point dir, Size size, string imgFilePath): base(pos, dir, size)
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
    }
}
