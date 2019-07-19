using System;
using System.Drawing;

namespace Game_Asteroids
{
    /// <summary>
    /// Базовый игровой объект
    /// </summary>
    abstract class BaseObject: ICollision
    {
        public delegate void Message();

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

        /// <summary>
        /// Получает позицию объектоа
        /// </summary>
        /// <returns></returns>
        public virtual Point GetPosition()
        {
            return this.Pos;
        }

        /// <summary>
        /// Получает размер объекта
        /// </summary>
        /// <returns></returns>
        public virtual Size GetSize()
        {
            return this.Size;
        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.X > Game.Width) throw new GameObjectException($"{this.GetType()}: некорректная координата по оси Х");
            if (pos.Y < 0 || pos.Y > Game.Height) throw new GameObjectException($"{this.GetType()}: некорректная координата по оси Y");

            if (size.Width<=0 || size.Height <= 0) throw new GameObjectException($"{this.GetType()}: размер не может быть отрицательным");

            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Создание прямоугольника, соответствующего координатам и размеру объетка для метода Collision
        /// </summary>
        public Rectangle Rect => new Rectangle(Pos, Size);

        /// <summary>
        /// Проверка объектов на столкновение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }

        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Обновление координат нахождения объекта по указанному смещению
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }

        /// <summary>
        /// Смещение объекта на случайную позицию правой границы
        /// </summary>
        public virtual void NewPosition()
        {
            Random r = new Random();
            this.Pos.X = Game.Width;
            this.Pos.Y = r.Next(1, Game.Height - this.Size.Height);
        }

    }
}
