using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Net.Http;
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Window
    {
        public AuthPage()
        {
            FillGridAsync();
            InitializeComponent();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public async void FillGridAsync()
        {
                string _url = "https://localhost:7120/GetAllUsers";
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(_url);
                    if (response != null)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        List<Users> res = JsonConvert.DeserializeObject<List<Users>>(json);
                    foreach (Users user in res)
                    {
                        listview.Items.Add(user.Login);
                    }

                    }
                }
        }
    }
}
