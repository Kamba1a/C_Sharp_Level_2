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
    /// Окно редактирования данных работника
    /// </summary>
    public partial class Win_EmployeeEdit : Window
    {
        /// <summary>
        /// Ссылка на выбранного работника в ListView в окне с общим списком работников
        /// </summary>
        Employee _selectedEmployee = Win_Employees.GetSelectedEmployee();

        /// <summary>
        /// Ссылка на общую коллекцию департаментов
        /// </summary>
        ObservableCollection<Department> _departments = Win_Departments.Departments;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Win_EmployeeEdit()
        {
            InitializeComponent();

            txtBlck_ID.Text = _selectedEmployee.ID.ToString("d3");
            txtBx_FirstName.Text = _selectedEmployee.FirstName;
            txtBx_SecondName.Text = _selectedEmployee.SecondName;
            txtBx_Position.Text= _selectedEmployee.Position;
            txtBx_Salary.Text = _selectedEmployee.Salary.ToString();
            CmbBox_Departmenrs.ItemsSource = _departments;
            if (_selectedEmployee.Department != null)
            {
                CmbBox_Departmenrs.Text = _selectedEmployee.Department.ToString();
            }
        }

        /// <summary>
        /// Кнопка "ОК" - сохранить внесенные изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_FirstName.Text != "" && txtBx_Position.Text != "" && txtBx_SecondName.Text != "" && txtBx_Salary.Text!="" && CmbBox_Departmenrs.Text != "")
            {
                if (int.TryParse(txtBx_Salary.Text, out int salary))
                {
                    _selectedEmployee.FirstName = txtBx_FirstName.Text;
                    _selectedEmployee.SecondName = txtBx_SecondName.Text;
                    _selectedEmployee.Position = txtBx_Position.Text;
                    _selectedEmployee.Salary = salary;
                    _selectedEmployee.Department = _departments[CmbBox_Departmenrs.SelectedIndex];
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
            Close();
        }
    }
}
