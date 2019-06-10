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

        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size, string imgFilePath): base(pos, dir, size)
        {
            _img = Image.FromFile(imgFilePath);
            Power = 1;
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
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) this.NewPosition();
        }
    }
}
