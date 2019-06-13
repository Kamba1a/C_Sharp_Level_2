using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ольга Назарова
Задание 2. Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
a.  для целых чисел;
b.  * для обобщенной коллекции; [?? непонятный пункт, т.к. List<T> и так обобщенная коллекция]
c.  ** используя Linq.
*/

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 2.
            //Дана коллекция List<T>.
            //Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции

            List<int> list = new List<int>();

            Console.WriteLine("Заполняем list случайными числами:\n");
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                list.Add(rand.Next(1, 10));
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            


            //Подсчет элементов с использованием Dictionary<TKey,TValue>

            Dictionary<int,int> dict = new Dictionary<int,int>();

            for (int i=0; i<list.Count; i++)
            {
                if (!dict.ContainsKey(list[i]))
                {
                    dict.Add(list[i],1);
                }
                else dict[list[i]]= dict[list[i]]+1;
            }

            Console.WriteLine("\nПодсчет элементов с использованием Dictionary<TKey,TValue>:");
            Console.WriteLine("====================");
            Console.WriteLine("Элемент | Количество");
            foreach (KeyValuePair<int,int> kvp in dict)
            {
                Console.WriteLine($"   {kvp.Key,-4} | {kvp.Value,5}");
            }
            Console.WriteLine("====================");



            // Подсчет элементов используя только методы List<T>

            List<int> list2 = new List<int>();
            list2.AddRange(list);

            Console.WriteLine("\nПодсчет элементов используя только методы List<T>:");
            Console.WriteLine("====================");
            Console.WriteLine("Элемент | Количество");
            while (list2.Count>0)
            {
                int elem = list2[0];
                int elemCount = list2.FindAll(n => n==elem).Count;
                Console.WriteLine($"   {elem,-4} | {elemCount,5}");
                list2.RemoveAll(n => n==elem);
            }
            Console.WriteLine("====================");



            // 2c.	** используя Linq.

            List<int> list3 = new List<int>();
            list3.AddRange(list);

            Console.WriteLine("\nПодсчет элементов используя Linq:");
            Console.WriteLine("====================");
            Console.WriteLine("Элемент | Количество");
            while (list3.Count > 0)
            {
                int elem = list3[0];
                int elemCount = (from n in list3 where n == elem select n).Count();
                Console.WriteLine($"   {elem,-4} | {elemCount,5}");
                list3.RemoveAll(n => n == elem);
            }
            Console.WriteLine("====================");



            Console.ReadKey();
        }
    }
}
