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

        /// <summary>
        /// Сила астероида
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Жизнь астероида
        /// </summary>
        public int HP { get; set; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Random r = new Random();
            Power = r.Next(1,4);
            HP = Power;
            switch (Power)
            {
                case 1: _img = Image.FromFile("asteroid1.png"); break;
                case 2: _img = Image.FromFile("asteroid2.png"); break;
                case 3: _img = Image.FromFile("asteroid3.png"); break;
            }
        }

        /// <summary>
        /// Отрисовка астероида
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление координат нахождения астероида по указанному смещению
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                this.HP = Power;
                this.NewPosition();
            }
        }

        /// <summary>
        /// Смещение астероида на правую границу с изменением размера и скорости
        /// </summary>
        public override void NewPosition()
        {
            Random r = new Random();
            int randSize = r.Next(25, 40);
            Size = new Size(randSize, randSize);
            Dir = new Point(r.Next(10, 15), 0);
            Pos.X = Game.Width;
            Pos.Y = r.Next(1, Game.Height - this.Size.Height);
        }
    }
}
