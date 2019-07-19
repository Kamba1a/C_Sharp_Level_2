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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Окно списка департаментов
    /// </summary>
    public partial class Win_Departments : Window
    {
        /// <summary>
        /// коллекция департаментов
        /// </summary>
        public static ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>()
        {
            new Department($"Департамент 1"),
            new Department($"Департамент 2"),
            new Department($"Департамент 3"),
            new Department($"Департамент 4")
        };

        /// <summary>
        /// Индекс выбранного элемента в списке ListBox lst_Departments
        /// </summary>
        static int _selectedListBoxItemIndex;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Win_Departments()
        {
            InitializeComponent();
            lst_Departments.ItemsSource = Departments;
        }

        /// <summary>
        /// Выбранный в ListBox департамент
        /// </summary>
        /// <returns></returns>
        public static Department GetSelectedDepartment()
        {
            return Departments[_selectedListBoxItemIndex];
        }

        /// <summary>
        /// Кнопка "Добавить" - открывает окно для добавления нового департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Win_DepartmentAdd win_departmentAdd = new Win_DepartmentAdd();
            win_departmentAdd.Owner = this;
            win_departmentAdd.Show();
        }

        /// <summary>
        /// Кнопка "Удалить" - удаление департамента из списка после подтверждения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Departments.SelectedItem != null)
            {
                MessageBoxResult confirm = MessageBox.Show("Вы уверены, что хотите удалить департамент?", "Подтвердите удаление", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes) Departments.RemoveAt(lst_Departments.SelectedIndex);
            }
            else MessageBox.Show("Для удаления выберите департамент в списке");
        }

        /// <summary>
        /// Кнопка "Редактировать" - редактирование названия департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Departments.SelectedItem != null)
             {
                _selectedListBoxItemIndex = lst_Departments.SelectedIndex;
                Win_DepartmentEdit win_departmentEdit = new Win_DepartmentEdit();
                win_departmentEdit.Owner = this;
                win_departmentEdit.Show();
            }
            else MessageBox.Show("Для редактирования выберите департамент в списке");
        }

        /// <summary>
        /// Кнопка "К общему списку сотрудников" - открывает окно с общим списком сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_GenListEmpl_Click(object sender, RoutedEventArgs e)
        {
            Win_Employees win_Employees = new Win_Employees();
            win_Employees.Show();
            this.Close();
        }
    }
}
