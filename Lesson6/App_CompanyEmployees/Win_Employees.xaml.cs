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
        public static ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>()
        {
            new Employee($"Имя1", $"Фамилия1", $"Должность1", 20000),
            new Employee($"Имя2", $"Фамилия2", $"Должность2", 30000),
            new Employee($"Имя3", $"Фамилия3", $"Должность3", 40000),
            new Employee($"Имя4", $"Фамилия4", $"Должность4", 50000)
        };

        /// <summary>
        /// Индекс выбранного в ListView работника из коллекции
        /// </summary>
        static int _selectedListBoxItemIndex { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Win_Employees()
        {
            InitializeComponent();
            lst_Employees.ItemsSource = Employees;
        }

        /// <summary>
        /// Выбранный в ListView работник
        /// </summary>
        /// <returns></returns>
        public static Employee GetSelectedEmployee()
        {
            return Employees[_selectedListBoxItemIndex];
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
                if (confirm == MessageBoxResult.Yes) Employees.RemoveAt(lst_Employees.SelectedIndex);
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
                _selectedListBoxItemIndex = lst_Employees.SelectedIndex;
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
        private void btn_DepartmentList_Click(object sender, RoutedEventArgs e)
        {
            Win_Departments win_Departments = new Win_Departments();
            win_Departments.Show();
            this.Close();
        }
    }
}
