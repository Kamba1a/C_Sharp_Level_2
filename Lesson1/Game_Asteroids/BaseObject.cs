using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Базовый игровой объект
    /// </summary>
    class BaseObject
    {
        /// <summary>
        /// Координаты нахождения объекта
        /// </summary>
        protected Point Pos;

        /// <summary>
        /// Координаты смещения объекта
        /// </summary>
        protected Point Dir;

        /// <summary>
        /// Размер объекта
        /// </summary>
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление координат нахождения объекта по указанному смещению
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }
    }
}
