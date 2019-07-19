using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Работники с фиксированной оплатой
    /// </summary>
    class FixedWageWorker: Worker
    {
        public FixedWageWorker(string firstName, string secondName, double salary) : base(firstName, secondName, salary)
        {
        }

        /// <summary>
        /// Метод рассчета среднемесячной заработной платы
        /// </summary>
        /// <returns></returns>
        public override double AverageMonth()
        {
            return Salary;
        }
    }
}
