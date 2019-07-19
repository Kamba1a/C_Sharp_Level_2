using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Asteroids
{
    /// <summary>
    /// Основной класс игры
    /// </summary>
    class Game
    {
        //обобщенный делегат для ведения журнала
        public static Action<string> WriteLog;

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
        private static Ship _ship;

        /// <summary>
        /// Аптечка
        /// </summary>
        private static RepairKit _repairKit;

        /// <summary>
        /// Счетчик очков за сбитые астероиды
        /// </summary>
        private static int _score = 0;

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();

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
        public static void Init(System.Windows.Forms.Form form)
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

            form.KeyDown += Form_KeyDown;

            Ship.MessageDie += Finish;
            //подписка на методы ведения записей событий
            WriteLog += WriteLogToConsole;
            WriteLog += WriteLogToFile;

            WriteLog?.Invoke("Начало игры");

            //Timer _timer = new Timer { Interval = 100 };
            //_timer.Interval = 100;
            _timer.Start();
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Обработчик событий нажатия клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                WriteLog?.Invoke("Нажата клавиша [Ctrl] - произведен выстрел");
                _bullet = new Bullet(new Point(_ship.Rect.X + _ship.GetSize().Width, _ship.Rect.Y + _ship.GetSize().Height / 2), new Point(50, 0), new Size(15, 3));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
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
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 250, 50);
            Buffer.Graphics.DrawString("Your score: " + _score, new Font(FontFamily.GenericSansSerif, 30), Brushes.White, 300, 150);
            Buffer.Render();
         }


        /// <summary>
        /// Отрисовка игровых объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _backObjects) obj.Draw();
            foreach (Asteroid ast in _asteroids) ast?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null) Buffer.Graphics.DrawString("Ship HP:" + _ship.HP, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            if (_ship != null) Buffer.Graphics.DrawString("Score: " + _score, SystemFonts.DefaultFont, Brushes.White, 0, 15);
            _repairKit?.Draw();

            Buffer.Render();
        }

        /// <summary>
        /// Обновление позиции игровых объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _backObjects) obj.Update();
            _bullet?.Update();

            for (int i = 0; i < _asteroids.Length; i++)
            {
                //if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    WriteLog?.Invoke("Попадание снаряда в астероид");
                    _score++;
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i].NewPosition();
                    _bullet = null;
                    continue;
                }

                if (_ship.Collision(_repairKit))
                {
                    WriteLog?.Invoke("Собрана аптечка");
                    _repairKit.NewPosition();
                    _ship.HPHigh(Rnd.Next(1, 10));
                }

                if (!_ship.Collision(_asteroids[i])) continue;
                WriteLog?.Invoke("Столкновение астероида с кораблем");
                _ship?.HPLow(Rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                _asteroids[i].NewPosition();

                if (_ship.HP <= 0) _ship?.Die();
            }
            _repairKit?.Update();
        }

        /// <summary>
        /// Создание игровых объетков при загрузке игры
        /// </summary>
        public static void Load()
        {
            _backObjects = new BaseObject[50];

            int randSize;
            int randSpeed;
            int randPos;

            for (int i = 0; i < 20; i++)
            {
                randPos = Rnd.Next(1, Game.Width);
                randSpeed = Rnd.Next(1, 5);

                _backObjects[i] = new FarStar(new Point(randPos, i * Game.Height/20 + 10), new Point(randSpeed, 0), new Size(2, 2));
            }

            for (int i = 20; i < 30; i++)
            {
                randPos = Rnd.Next(1, Game.Width);
                randSpeed = Rnd.Next(15, 30);
                randSize = Rnd.Next(3,10);

                _backObjects[i] = new FarAsteroid(new Point(randPos, (i-20) * Game.Height / 10 + 20), new Point(randSize, 0), new Size(randSize, randSize));
            }

            for (int i = 30; i < 50; i++)
            {
                randPos = Rnd.Next(1, Game.Width);
                randSpeed = Rnd.Next(2, 5);
                randSize = Rnd.Next(3, 10);
                
                _backObjects[i] = new Star(new Point(randPos, (i - 30) * Game.Height / 20 + 20), new Point(randSpeed, 0), new Size(randSize, randSize));
            }

            _asteroids = new Asteroid[5];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                randPos = Rnd.Next(1, Game.Width);
                randSpeed = Rnd.Next(15, 25);

                _asteroids[i] = new Asteroid(new Point(Game.Width, Rnd.Next(1,Game.Height-45)), new Point(randSpeed, 0), new Size(35, 35), "asteroid.png");
            }

            _repairKit = new RepairKit(new Point(Game.Width, Rnd.Next(1, Game.Height - 35)), new Point(10, 0), new Size(30, 30), "repair_kit.jpg");
            _ship = new Ship(new Point(50, 300), new Point(0, 10), new Size(70, 30), "ship.jpg");
        }

        //метод для ведения записей событий в консоли
        private static void WriteLogToConsole(string msg)
        {
            Console.WriteLine($"{DateTime.Now}: {msg}.\n");
        }

        //метод для ведения записей событий в файл
        private static void WriteLogToFile(string msg)
        {
            System.IO.File.AppendAllText("log.txt", $"{DateTime.Now}: {msg}.\n");
        }
    }
}
