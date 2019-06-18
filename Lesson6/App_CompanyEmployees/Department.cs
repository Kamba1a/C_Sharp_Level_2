using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace App_CompanyEmployees
{
    /// <summary>
    /// Класс "Департамент"
    /// </summary>
    public class Department: INotifyPropertyChanged
    {
        private string _name;

        /// <summary>
        /// Название департамента
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }

            }
        }

        /// <summary>
        /// Конструктор (Название)
        /// </summary>
        /// <param name="name"></param>
        public Department(string name)
        {
            Name = name;
        }

        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Уведомление об изменении какого-либо свойства класса
        /// </summary>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
