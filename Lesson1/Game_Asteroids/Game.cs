﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Asteroids
{
    /// <summary>
    /// Основной класс игры
    /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        /// <summary>
        /// Массив с игровыми объектами
        /// </summary>
        public static BaseObject[] _objs;

        /// <summary>
        /// Космический корабль
        /// </summary>
        public static Ship ship;

        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;

            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;

            // Создаем объект (поверхность рисования) и связываем его с формой
            g = form.CreateGraphics();

            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Таймер повтора событий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Отрисовка игровых объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            ship.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление координат нахождения игровых объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            ship.Update();
        }

        /// <summary>
        /// Создание игровых объетков
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[55];

            Random r = new Random();
            int randSize;
            int randSpeed;
            int randPos;

            for (int i = 0; i < 20; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(1, 5);

                _objs[i] = new BaseObject(new Point(randPos, i * 30 + 10), new Point(randSpeed, 0), new Size(2, 2));
            }

            for (int i = 20; i < 30; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(15, 30);
                randSize = r.Next(3,15);

                _objs[i] = new FarAsteroid(new Point(randPos, (i-20) * 57 + 20), new Point(randSize, 0), new Size(randSize, randSize));
            }

            for (int i = 30; i < 50; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(2, 5);
                randSize = r.Next(3, 10);
                
                _objs[i] = new Star(new Point(randPos, (i - 30) * 27 + 20), new Point(randSpeed, 0), new Size(randSize, randSize));
            }

            for (int i = 50; i < 55; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(15, 25);
                randSize = r.Next(20, 35);

                _objs[i] = new Asteroid(new Point(randPos, (i - 50) * 115 + 20), new Point(randSpeed, 0), new Size(randSize, randSize), "asteroid.jpg");
            }

            ship = new Ship(new Point(100, 300), new Point(5, 10), new Size(60, 25), "ship.jpg");

        }
    }
}
