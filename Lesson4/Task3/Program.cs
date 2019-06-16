using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ольга Назарова

Задание 3. * Дан фрагмент программы:

    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"four",4 },
        {"two",2 },
        { "one",1 },
        {"three",3 },
    };
    var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
    foreach (var pair in d)
    {
        Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
    }

а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
b. * Развернуть обращение к OrderBy с использованием делегата .
*/

namespace Task3
{
    class Program
    {
        //делегат для пункта b
        delegate int myDelegate(KeyValuePair<string, int> pair);

        static void Main(string[] args)
        {
            //Исходный код

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            Console.WriteLine();



            //а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>

            Dictionary<string, int> dict2 = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            var d2 = dict2.OrderBy( pair => pair.Value );
            foreach (var pair in d2) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            Console.WriteLine();



            //b. * Развернуть обращение к OrderBy с использованием делегата

            Dictionary<string, int> dict3 = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            int myMethod(KeyValuePair <string, int> pair)
            {
                return pair.Value;
            }

            //OrderBy принимает параметром только обобщенный делегат, поэтому, как хотелось, со своим делегатом не заработает:
            //myDelegate md = new myDelegate(myMethod);

            Func<KeyValuePair<string, int>, int> md = myMethod;

            var d3 = dict3.OrderBy(md);
            foreach (var pair in d3) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);


            Console.ReadKey();
        }
    }
}
