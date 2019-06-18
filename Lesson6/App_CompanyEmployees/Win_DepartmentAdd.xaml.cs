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
    /// Окно добавления нового департамента
    /// </summary>
    public partial class Win_DepartmentAdd : Window
    {
        public Win_DepartmentAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка "ОК" - добавить новый департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_input.Text != "")
            {
                Win_Departments.DepartmentAdd(new Department(txtBox_input.Text));
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
            this.Close();
        }
    }
}
