using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Asteroids
{
    class GameObjectException: Exception
    {
        public GameObjectException()
        {
            Console.WriteLine("Недопустимые параметры объекта");
        }

        public GameObjectException(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
