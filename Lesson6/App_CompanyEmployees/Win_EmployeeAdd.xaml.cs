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
    /// Окно добавления нового работника
    /// </summary>
    public partial class Win_EmployeeAdd : Window
    {
        public Win_EmployeeAdd()
        {
            InitializeComponent();

            CmbBox_Departmenrs.ItemsSource = Win_Departments.GetDepartments();
        }

        /// <summary>
        /// Кнопка "ОК" - добавить нового работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_FirstName.Text!="" && txtBx_Position.Text != "" && txtBx_SecondName.Text != "" && txtBx_Salary.Text != "" && CmbBox_Departmenrs.Text!="")
            {
                if (int.TryParse(txtBx_Salary.Text, out int salary))
                {
                    Win_Employees.EmployeeAdd(txtBx_FirstName.Text, txtBx_SecondName.Text, txtBx_Position.Text, salary, Win_Departments.GetDepartments()[CmbBox_Departmenrs.SelectedIndex]);
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
