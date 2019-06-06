using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ольга Назарова

Задание 1:
Построить  три  класса  (базовый  и  2  потомка),  описывающих  работников с  почасовой  оплатой (один  из  потомков)  и  фиксированной оплатой (второй потомок):
 
a.	Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
 Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»;
 для  работников  с  фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
 
b.	Создать на базе абстрактного класса массив сотрудников и заполнить его;
 
c.	* Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort();
 
d.	* Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
*/

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkersTable workers = new WorkersTable(6);
            workers[0] = new FixedWageWorker("Ольга", "Петрова", 30000);
            workers[1] = new FixedWageWorker("Елена", "Иванова", 24000);
            workers[2] = new FixedWageWorker("Ирина", "Сидорова", 45000);
            workers[3] = new HourlyWageWorker("Сергей", "Иванов", 250);
            workers[4] = new HourlyWageWorker("Егор", "Сидоров", 300);
            workers[5] = new HourlyWageWorker("Евгений", "Петров", 200);

            Console.WriteLine("Массив с работниками:");
            workers.PrintTable();
            Console.WriteLine();

            workers.Sort();

            Console.WriteLine("После сортировки:");
            foreach (Worker w in workers) Console.WriteLine(w);

            Console.ReadKey();
        }
    }
}
