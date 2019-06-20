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
    /// Окно добавления нового работника в выбранный департамент
    /// </summary>
    public partial class Win_EmployeeAddToDepartment : Window
    {
        /// <summary>
        /// Ссылка на выбранный департамент в ListBox окна с общим списком департаментов
        /// </summary>
        Department _openedDepartment = Win_Departments.GetSelectedDepartment();

        /// <summary>
        /// Ссылка на общую коллекцию работников
        /// </summary>
        ObservableCollection<Employee> _employees = Win_Employees.Employees;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Win_EmployeeAddToDepartment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка "ОК" - добавить нового работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_FirstName.Text != "" && txtBx_Position.Text != "" && txtBx_SecondName.Text != "" && txtBx_Salary.Text != "")
            {
                if (int.TryParse(txtBx_Salary.Text, out int salary))
                {
                    _employees.Add(new Employee (txtBx_FirstName.Text, txtBx_SecondName.Text, txtBx_Position.Text, salary, _openedDepartment));
                    this.Close();
                }
                else MessageBox.Show("Некорректные символы в поле \"Оклад\"");
            }
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
