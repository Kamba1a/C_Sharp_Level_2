using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Класс "Работник"
    /// </summary>
    public class Employee: INotifyPropertyChanged
    {
        private string _firstName;
        private string _secondName;
        private string _position;
        private Department _department;
        private int _salary;

        /// <summary>
        /// Имя работника
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        /// <summary>
        /// Фамилия работника
        /// </summary>
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (_secondName != value)
                {
                    _secondName = value;
                    NotifyPropertyChanged("SecondName");
                }
            }
        }

        /// <summary>
        /// Должность работника
        /// </summary>
        public string Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    NotifyPropertyChanged("Position");
                }
            }
        }

        /// <summary>
        /// Оклад работника
        /// </summary>
        public int Salary
        {
            get { return _salary; }
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    NotifyPropertyChanged("Salary");
                }
            }
        }

        /// <summary>
        /// Департамент, в котором числится работник
        /// </summary>
        public Department Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    NotifyPropertyChanged("Department");
                }
            }
        }

        /// <summary>
        /// Индивидуальный номер работника
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Счетчик созданных экземпляров класса, для уникального ID
        /// </summary>
        private static int _idCounter = 0;

        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Конструктор (Имя, Фамилия, Должность)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        public Employee(string firstName, string secondName, string position, int salary)
        {
            ID = ++_idCounter;
            FirstName = firstName;
            SecondName = secondName;
            Position = position;
            Salary = salary;
        }

        /// <summary>
        /// Конструктор (Имя, Фамилия, Должность, Департамент)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        /// <param name="department"></param>
        public Employee(string firstName, string secondName, string position, int salary, Department department)
        {
            ID = _idCounter++;
            FirstName = firstName;
            SecondName = secondName;
            Position = position;
            Salary = salary;
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
            if (Department!=null) return $"{SecondName} {FirstName}, {Position} [{Department}], оклад: {Salary}";
            else return $"[ID: {ID:d3}] {SecondName} {FirstName}, {Position} [Департамент не определен], оклад: {Salary}";
        }
    }
}
