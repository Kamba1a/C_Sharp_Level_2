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
    /// Окно редактирования названия департамента
    /// </summary>
    public partial class Win_DepartmentEdit : Window
    {
        public Win_DepartmentEdit()
        {
            InitializeComponent();

            txtBox_input.Text = Win_Departments.GetDepartments()[Win_Departments.SelectedListBoxItemIndex].Name;
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

        /// <summary>
        /// Кнопка "ОК" - сохранить новое название департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_input.Text != "")
            {
                Win_Departments.DepartmentNameEdit(txtBox_input.Text);
                MessageBox.Show("Данные реально редактируются, но в ListBox обновление не проходит, пока не понятно как это реализовать.."); //временно
                this.Close();
            }
        }
    }
}
