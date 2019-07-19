using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Окно общего списка работников
    /// </summary>
    public partial class Win_Employees : Window
    {
        /// <summary>
        /// Коллекция работников
        /// </summary>
        static ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();

        public static int SelectedListBoxItemIndex { get; set; }

        public Win_Employees()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++) _employees.Add(new Employee($"Имя{i + 1}", $"Фамилия{i + 1}", $"Должность{i + 1}"));

            lst_Employees.ItemsSource = _employees; // работает с перегруженным методом ToString(), но не обновляет ListBox при редактировании поля класса

            _employees.Add(new Employee($"Имя4", $"Фамилия4", $"Должность4"));
        }

        /// <summary>
        /// Добавить работника в коллекцию
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        /// <param name="department"></param>
        public static void EmployeeAdd(string firstName, string secondName, string position, Department department)
        {
            _employees.Add(new Employee(firstName, secondName, position, department));
        }

        /// <summary>
        /// Редкатировать данные работника
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="position"></param>
        /// <param name="department"></param>
        public static void EmployeeEdit(string firstName, string secondName, string position, Department department) //!!! при редактировании ничего не меняется в ListBox!
        {
            _employees[SelectedListBoxItemIndex].FirstName = firstName;
            _employees[SelectedListBoxItemIndex].SecondName = secondName;
            _employees[SelectedListBoxItemIndex].Position = position;
            _employees[SelectedListBoxItemIndex].Department = department;
        }

        /// <summary>
        /// Получить доступ к коллекции работников
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Employee> GetEmployeesCollection()
        {
            return _employees;
        }

        /// <summary>
        /// Кнопка "Добавить" - октрытие окна для добавления нового работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Win_EmployeeAdd win_employeeAdd = new Win_EmployeeAdd();
            win_employeeAdd.Owner = this;
            win_employeeAdd.Show();
        }

        /// <summary>
        /// Кнопка "Удалить" - удаление работника из списка после подтверждения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Employees.SelectedItem != null)
            {
                MessageBoxResult confirm = MessageBox.Show("Вы уверены, что хотите удалить работника?", "Подтвердите удаление", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes) _employees.RemoveAt(lst_Employees.SelectedIndex);
            }
            else MessageBox.Show("Для удаления выберите департамент в списке");
        }

        /// <summary>
        /// Кнопка "Редактировать" - открывает окно редактирования данных работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Employees.SelectedItem != null)
            {
                SelectedListBoxItemIndex = lst_Employees.SelectedIndex;
                Win_EmployeeEdit win_employeeEdit = new Win_EmployeeEdit();
                win_employeeEdit.Owner = this;
                win_employeeEdit.Show();
            }
            else MessageBox.Show("Для редактирования выберите работника в списке");
        }

        /// <summary>
        /// Кнопка "К списку департаментов" - открывает окно со списком департаментов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DepartmentList_Click(object sender, RoutedEventArgs e)     // !!! Повторное открытие приводит к задваиванию списка в ListBox !!!
        {
            MessageBox.Show("Предполагалось, что будет простое переключение между окнами, но в итоге при повторном открытии задваивается список в ListBox"); //временно
            ///Понятно, что проблема из-за того, что каждый раз создаю новое окно, но как восстановить прежнее - не понятно (по имени окна обратиться к нему не получается)
            Win_Departments win_Departments = new Win_Departments();
            win_Departments.Show();
            this.Close();
        }
    }
}
