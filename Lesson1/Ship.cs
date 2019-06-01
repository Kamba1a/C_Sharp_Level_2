using System;
using System.Drawing;

namespace Lesson1
{
    class Ship : BaseObject
    {
        public Ship (Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Image img = Image.FromFile("ship.jpg");
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.Y = Pos.Y - Dir.Y;
            Pos.X = Pos.X - Dir.X;
            if (Pos.Y < 200 || Pos.Y > 400) Dir.Y = -Dir.Y;
            if (Pos.X < 100 || Pos.X > 130) Dir.X = -Dir.X;
        }

    }
}
