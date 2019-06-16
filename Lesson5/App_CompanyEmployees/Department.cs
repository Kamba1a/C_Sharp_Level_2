using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Класс "Департамент"
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор (Название)
        /// </summary>
        /// <param name="name"></param>
        public Department(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
