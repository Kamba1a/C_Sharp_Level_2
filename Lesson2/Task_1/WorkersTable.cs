using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Класс, содержащий массив работников
    /// </summary>
    class WorkersTable: IEnumerable
    {
        /// <summary>
        /// Массив с работниками
        /// </summary>
        private Worker[] _workers;

        public WorkersTable(int amountWorkers)
        {
            _workers = new Worker[amountWorkers];
        }

        public Worker this[int index]
        {
            get { return _workers[index]; }
            set { _workers[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _workers.Length; i++) yield return _workers[i];
        }

        /// <summary>
        /// Вывод в консоль всех работников из массива
        /// </summary>
        public void PrintTable()
        {
            Console.WriteLine("==Имя/Фамилия====Зарплата==");
            for (int i = 0; i< _workers.Length; i++) Console.WriteLine(_workers[i]);
            Console.WriteLine("=========================");
        }

        /// <summary>
        /// Сортировка работников по среднемесячной заработной плате
        /// </summary>
        public void Sort()
        {
            Array.Sort(_workers);
        }
    }
}
