using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Класс "Работник"
    /// </summary>
    public class Employee
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
        /// Должность работника
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Департамент, в котором числится работник
        /// </summary>
        public Department Department { get; set; }

        public int ID { get; private set; }

        private static int _idCounter = 0;

        /// <summary>
        /// Конструктор (Имя, Фамилия, Должность)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        public Employee(string firstName, string secondName, string position)
        {
            ID = ++_idCounter;
            FirstName = firstName;
            SecondName = secondName;
            Position = position;
        }

        /// <summary>
        /// Конструктор (Имя, Фамилия, Должность, Департамент)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        /// <param name="department"></param>
        public Employee(string firstName, string secondName, string position, Department department)
        {
            ID = _idCounter++;
            FirstName = firstName;
            SecondName = secondName;
            Position = position;
            Department = department;
        }

        /// <summary>
        /// Добавить работнику департамент
        /// </summary>
        /// <param name="department"></param>
        public void SetDepartment(Department department)
        {
            Department = department;
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Department!=null) return $"{SecondName} {FirstName}, {Position} [{Department}]";
            else return $"[ID: {ID:d3}] {SecondName} {FirstName}, {Position} [Департамент не определен]";
        }
    }
}
