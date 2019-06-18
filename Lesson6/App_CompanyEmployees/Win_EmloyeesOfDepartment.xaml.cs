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
    /// Окно со списком работников выбранного департамента
    /// </summary>
    public partial class Win_EmloyeesOfDepartment : Window
    {
        static ObservableCollection<Employee> _employeesOfDepartment = new ObservableCollection<Employee>();

        public Win_EmloyeesOfDepartment()
        {
            InitializeComponent();

            lbl_DepartmentName.Content = Win_Departments.GetDepartments()[Win_Departments.SelectedListBoxItemIndex].Name;

            lst_Employees.ItemsSource = from empl in Win_Employees.GetEmployeesCollection()                                                 //!!! не обновляет изменения !
                                        where empl.Department == Win_Departments.GetDepartments()[Win_Departments.SelectedListBoxItemIndex]
                                        select empl;
        }

        /// <summary>
        /// Кнопка "Добавить" - открывает окно для добавления нового работника
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
        /// Кнопка "Удалить" - должна удалять работника из общей коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Employees.SelectedItem != null)
            {
                Win_Employees.GetEmployeesCollection().Remove(lst_Employees.SelectedItem as Employee);
            }
            else MessageBox.Show("Для удаления выберите департамент в списке");
        }

        /// <summary>
        /// Кнопка "Редактировать" - должна открывать окно для редактирования данных работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (lst_Employees.SelectedItem != null)
            {
                MessageBox.Show("Пока не понятно как резализовать редактирование работника в общем списке через это окно.."); //временно
                //без идентификации работника открытие окна для редактирования будет вызывать ошибку:
                //Win_EmployeeEdit win_employeeEdit = new Win_EmployeeEdit();
                //win_employeeEdit.Owner = this;
                //win_employeeEdit.Show();
            }
            else MessageBox.Show("Для редактирования выберите работника в списке");
        }

        /// <summary>
        /// Кнопка "Закрыть" - закрывает текущее окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
