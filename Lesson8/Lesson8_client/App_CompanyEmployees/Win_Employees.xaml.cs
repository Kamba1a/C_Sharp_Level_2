using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Xml;
using System.IO;

namespace App_CompanyEmployees
{
    /// <summary>
    /// Окно общего списка работников
    /// </summary>
    public partial class Win_Employees : Window
    {

        public Win_Employees()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(@"http://localhost:51718");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var res = httpClient.GetStringAsync(@"http://localhost:51718/Employees").Result;

            XmlReader xmlReader = XmlReader.Create(new StringReader(res));
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            lst_Employees.DataContext = dataSet.Tables[0];
        }

        /// <summary>
        /// Кнопка "Найти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_searchID.Text != "")
            {
                if (int.TryParse(txtBx_searchID.Text, out int inputID))
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
                        var res = httpClient.GetStringAsync(@"http://localhost:51718/Employees" + $"/{inputID}").Result;
                        XmlReader xmlReader = XmlReader.Create(new StringReader(res));
                        DataSet dataSet = new DataSet();
                        dataSet.ReadXml(xmlReader);
                        lst_Employees.DataContext = dataSet.Tables[0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Работника с таким ID не существует");
                    }
                }
            }
        }

        /// <summary>
        /// Кнопка "Показать все"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var res = httpClient.GetStringAsync(@"http://localhost:51718/Employees").Result;

            XmlReader xmlReader = XmlReader.Create(new StringReader(res));
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            lst_Employees.DataContext = dataSet.Tables[0];
        }

        /// <summary>
        /// Кнопка "К списку департаментов" - открывает окно со списком департаментов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DepartmentList_Click(object sender, RoutedEventArgs e)
        {
            Win_Departments win_Departments = new Win_Departments();
            win_Departments.Show();
            this.Close();
        }
    }
}
