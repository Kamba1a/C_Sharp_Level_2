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
    /// Окно добавления нового работника
    /// </summary>
    public partial class Win_EmployeeAdd : Window
    {
        /// <summary>
        /// Ссылка на общую коллекцию работников
        /// </summary>
        ObservableCollection<Employee> _employees = Win_Employees.Employees;

        /// <summary>
        /// Ссылка на общую коллекцию департаментов
        /// </summary>
        ObservableCollection<Department> _departments = Win_Departments.Departments;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Win_EmployeeAdd()
        {
            InitializeComponent();
            CmbBox_Departmenrs.ItemsSource = _departments;
        }

        /// <summary>
        /// Кнопка "ОК" - добавить нового работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_FirstName.Text!="" && txtBx_Position.Text != "" && txtBx_SecondName.Text != "" && txtBx_Salary.Text != "")
            {
                if (CmbBox_Departmenrs.Text != "")
                {
                    if (int.TryParse(txtBx_Salary.Text, out int salary))
                    {
                        _employees.Add(new Employee(txtBx_FirstName.Text, txtBx_SecondName.Text, txtBx_Position.Text, salary, _departments[CmbBox_Departmenrs.SelectedIndex]));
                        this.Close();
                    }
                    else MessageBox.Show("Некорректные символы в поле \"Оклад\"");
                }
                else MessageBox.Show("Выберите департамент");
            }
            else MessageBox.Show("Заполните все поля");
        }

        /// <summary>
        /// Кнопка "Отмена" - закрыть окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
