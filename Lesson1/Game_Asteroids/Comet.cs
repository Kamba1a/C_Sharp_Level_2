using System;
using System.Drawing;

namespace Game_Asteroids
{
    class Comet: BaseObject
    {
        public Comet(Point pos, Point dir, Size size): base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Image img = Image.FromFile("comet.jpg");
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }

    }
}
