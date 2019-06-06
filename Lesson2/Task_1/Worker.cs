using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Базовый класс для работников
    /// </summary>
    abstract class Worker: IComparable<Worker>
    {
        /// <summary>
        /// Имя работника
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Заработная плата
        /// </summary>
        public double Salary { get; set; }

        protected Worker(string firstName, string secondName, double salary)
        {
            FirstName = firstName;
            SecondName = secondName;
            Salary = salary;
        }

        /// <summary>
        /// Метод расчета среднемесячной заработной платы
        /// </summary>
        /// <returns></returns>
        public abstract double AverageMonth();

        /// <summary>
        /// Сравнение работников по среднемесячной заработной плате
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public int CompareTo(Worker worker)
        {
            if (this.AverageMonth() > worker.AverageMonth()) return 1;
            if (this.AverageMonth() < worker.AverageMonth()) return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName,-10} - {this.AverageMonth()}";
        }
    }
}
