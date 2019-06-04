using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "Корабль"
    /// </summary>
    class Ship : BaseObject
    {
        /// <summary>
        /// Изображение объекта
        /// </summary>
        Image _img;

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
        /// Обновление координат нахождения объекта по указанному смещению
        /// </summary>
        public override void Update()
        {
            Pos.Y = Pos.Y - Dir.Y;
            Pos.X = Pos.X - Dir.X;
            if (Pos.Y < 200 || Pos.Y > 400) Dir.Y = -Dir.Y;
            if (Pos.X < 100 || Pos.X > 130) Dir.X = -Dir.X;
        }

    }
}
