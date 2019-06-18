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
        static ObservableCollection<Department> _departments = new ObservableCollection<Department>();

        /// <summary>
        /// Индекс выбранного элемента в списке ListBox lst_Departments
        /// </summary>
        public static int SelectedListBoxItemIndex { get ; set; }

        public Win_Departments()
        {
            InitializeComponent();
            
            for (int i = 0; i < 3; i++) _departments.Add(new Department($"Департамент {i + 1}"));

            lst_Departments.ItemsSource = _departments;

            _departments.Add(new Department($"Департамент 4"));
        }

        /// <summary>
        /// Добавляет новый департамент в коллекцию 
        /// </summary>
        /// <param name="department"></param>
        public static void DepartmentAdd(Department department)
        {
            _departments.Add(department);
        }

        /// <summary>
        /// Изменить имя департамента в коллекции
        /// </summary>
        /// <param name="newName"></param>
        public static void DepartmentNameEdit(string newName)
        {
            _departments[SelectedListBoxItemIndex].Name = newName;
        }

        /// <summary>
        /// Получить доступ к коллекции департаментов
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Department> GetDepartments()
        {
            return _departments;
        }

        public static Department GetSelectedDepartment()
        {
            return _departments[SelectedListBoxItemIndex];
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
                if (confirm == MessageBoxResult.Yes) _departments.RemoveAt(lst_Departments.SelectedIndex);
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
                SelectedListBoxItemIndex = lst_Departments.SelectedIndex;
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
        private void Btn_GenListEmpl_Click(object sender, RoutedEventArgs e)    // !!! Повторное открытие приводит к задваиванию списка в ListBox !!!
        {
            Win_Employees win_Employees = new Win_Employees();
            win_Employees.Show();
            this.Close();
        }

        /// <summary>
        /// Кнопка "Открыть.." - открывает окно со списком работников выбранного департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_openEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Departments.SelectedItem != null)
            {
                SelectedListBoxItemIndex = lst_Departments.SelectedIndex;
                Win_EmloyeesOfDepartment win_EmloyeesOfDepartment = new Win_EmloyeesOfDepartment();
                win_EmloyeesOfDepartment.Owner = this;
                win_EmloyeesOfDepartment.Show();
            }
            else MessageBox.Show("Для открытия выберите департамент в списке");
        }
    }
}
