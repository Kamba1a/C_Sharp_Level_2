using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Работники с почасовой оплатой
    /// </summary>
    class HourlyWageWorker: Worker
    {
        public HourlyWageWorker(string firstName, string secondName, double salary) : base(firstName, secondName, salary)
        {
        }

        /// <summary>
        /// Метод рассчета среднемесячной заработной платы
        /// </summary>
        /// <returns></returns>
        public override double AverageMonth()
        {
            double rez = 20.8 * 8 * Salary;
            return rez;
        }

        public override string ToString()
        {
            return base.ToString() + $" ({Salary}/час)";
        }
    }
}
