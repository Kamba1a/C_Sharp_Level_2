using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Объект "аптечка"
    /// </summary>
    class RepairKit : BaseObject
    {
        /// <summary>
        /// Изображение аптечки
        /// </summary>
        Image _img;

        public RepairKit(Point pos, Point dir, Size size, string imgFilePath) : base(pos, dir, size)
        {
            _img = Image.FromFile(imgFilePath);
        }

        /// <summary>
        /// Отрисовка аптечки
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление координат нахождения аптечки по указанному смещению
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            //if (Pos.X < 0) this.NewPosition();
        }
    }
}
