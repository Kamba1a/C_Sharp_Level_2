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

//Ольга Назарова
//
//Задание:
//Изменить WPF-приложение для ведения списка сотрудников компании (из урока 7), используя веб-сервисы.
//Разделите приложение на две части. Первая часть – клиентское приложение, отображающее данные.
//Вторая часть – веб-сервис и код, связанный с извлечением данных из БД. Приложение реализует только просмотр данных.
//При разработке приложения допустимо использовать любой из рассмотренных типов веб-сервисов.

namespace App_CompanyEmployees
{
    /// <summary>
    /// Окно списка департаментов
    /// </summary>
    public partial class Win_Departments : Window
    {
        public Win_Departments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Win_DepatrmentList_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(@"http://localhost:51718");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var res = httpClient.GetStringAsync(@"http://localhost:51718/Departments").Result;

            XmlReader xmlReader = XmlReader.Create(new StringReader(res));
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            lst_Departments.DataContext = dataSet.Tables[0];
        }

        /// <summary>
        /// Кнопка "Найти" - отображается департамент с искомым ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtBx_searchID.Text !="")
            {
                if (int.TryParse(txtBx_searchID.Text, out int inputID))
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
                        var res = httpClient.GetStringAsync(@"http://localhost:51718/Departments" + $"/{inputID}").Result;
                        XmlReader xmlReader = XmlReader.Create(new StringReader(res));
                        DataSet dataSet = new DataSet();
                        dataSet.ReadXml(xmlReader);
                        lst_Departments.DataContext = dataSet.Tables[0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("Департамента с таким ID не существует");
                    }
                }
            }
        }

        /// <summary>
        /// Кнопка "Показать все" - выводит все департаменты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            var res = httpClient.GetStringAsync(@"http://localhost:51718/Departments").Result;

            XmlReader xmlReader = XmlReader.Create(new StringReader(res));
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            lst_Departments.DataContext = dataSet.Tables[0];
        }

        /// <summary>
        /// Кнопка "К общему списку сотрудников" - открывает окно с общим списком сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_GenListEmpl_Click(object sender, RoutedEventArgs e)
        {
            Win_Employees win_Employees = new Win_Employees();
            win_Employees.Show();
            this.Close();
        }
     }
}
