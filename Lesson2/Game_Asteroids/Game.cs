using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

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
        /// Фоновые объекты
        /// </summary>
        private static BaseObject[] _backObjects;

        /// <summary>
        /// Астероиды
        /// </summary>
        private static Asteroid[] _asteroids;

        /// <summary>
        /// Пуля
        /// </summary>
        private static Bullet _bullet;

        /// <summary>
        /// Космический корабль
        /// </summary>
        public static Ship ship;

        // Ширина и высота игрового поля
        static int _width;
        static int _height;
        public static int Width
        {
            get { return _width; }
            set
            {
                if (value < 160 || value > 1000) throw new ArgumentOutOfRangeException("Недопустимая ширина окна");
                else _width = value;
            }
        }
        public static int Height {
            get { return _height; }
            set
            {
                if (value < 120 || value > 1000) throw new ArgumentOutOfRangeException("Недопустимая высота окна");
                else _height = value;
            }
        }

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
            foreach (BaseObject obj in _backObjects) obj.Draw();
            foreach (Asteroid ast in _asteroids) ast.Draw();
            _bullet.Draw();
            ship.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление координат нахождения игровых объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _backObjects) obj.Update();
            foreach (Asteroid ast in _asteroids)
            {
                ast.Update();
                if (ast.Collision(_bullet))
                {
                    ast.NewPosition();
                    _bullet.NewShot(ship);
                }
                if (ast.Collision(ship)) ast.NewPosition();
            }
            _bullet.Update();
            if (_bullet.GetPosition().X > Game.Width) _bullet.NewShot(ship);
            ship.Update();
        }

        /// <summary>
        /// Создание игровых объетков при загрузке игры
        /// </summary>
        public static void Load()
        {
            _backObjects = new BaseObject[50];

            Random r = new Random();
            int randSize;
            int randSpeed;
            int randPos;

            for (int i = 0; i < 20; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(1, 5);

                _backObjects[i] = new FarStar(new Point(randPos, i * Game.Height/20 + 10), new Point(randSpeed, 0), new Size(2, 2));
            }

            for (int i = 20; i < 30; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(15, 30);
                randSize = r.Next(3,10);

                _backObjects[i] = new FarAsteroid(new Point(randPos, (i-20) * Game.Height / 10 + 20), new Point(randSize, 0), new Size(randSize, randSize));
            }

            for (int i = 30; i < 50; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(2, 5);
                randSize = r.Next(3, 10);
                
                _backObjects[i] = new Star(new Point(randPos, (i - 30) * Game.Height / 20 + 20), new Point(randSpeed, 0), new Size(randSize, randSize));
            }

            _asteroids = new Asteroid[5];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                randPos = r.Next(1, Game.Width);
                randSpeed = r.Next(15, 25);

                _asteroids[i] = new Asteroid(new Point(Game.Width, r.Next(1,Game.Height-35)), new Point(randSpeed, 0), new Size(30, 30), "asteroid.jpg");
            }

            ship = new Ship(new Point(100, 300), new Point(5, 10), new Size(70, 30), "ship.jpg");
            _bullet = new Bullet(new Point(0, 0), new Point(50, 0), new Size(15, 3));
            _bullet.NewShot(ship);
        }
    }
}
