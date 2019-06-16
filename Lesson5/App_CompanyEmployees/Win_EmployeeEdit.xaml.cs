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

namespace App_CompanyEmployees
{
    /// <summary>
    /// Окно редактирования данных работника
    /// </summary>
    public partial class Win_EmployeeEdit : Window
    {
        public Win_EmployeeEdit()
        {
            InitializeComponent();

            txtBlck_ID.Text = Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].ID.ToString("d3");
            CmbBox_Departmenrs.ItemsSource = Win_Departments.GetDepartments();
            txtBx_FirstName.Text = Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].FirstName;
            txtBx_SecondName.Text = Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].SecondName;
            txtBx_Position.Text= Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].Position;
            if (Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].Department != null)
            {
                CmbBox_Departmenrs.Text = Win_Employees.GetEmployeesCollection()[Win_Employees.SelectedListBoxItemIndex].Department.ToString();
            }
        }

        /// <summary>
        /// Кнопка "ОК" - сохранить внесенные изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_FirstName.Text != "" && txtBx_Position.Text != "" && txtBx_SecondName.Text != "" && CmbBox_Departmenrs.Text != "")
            {
                Win_Employees.EmployeeEdit(txtBx_FirstName.Text, txtBx_SecondName.Text, txtBx_Position.Text, Win_Departments.GetDepartments()[CmbBox_Departmenrs.SelectedIndex]);
                MessageBox.Show("Данные реально редактируются, но в ListBox обновление не проходит, пока не понятно как это реализовать.."); //временно
                this.Close();
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
