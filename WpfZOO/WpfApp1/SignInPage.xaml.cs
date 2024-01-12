using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Window
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _str = "https://localhost:7120/CreateUser?login=";
                string _url = _str + ttbLogin.Text + "&password=" + ttbPassword.Text;
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(_url);
                    if (response != null)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        if (json != null)
                        {
                            MessageBox.Show("Created Succesfurry");
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль попробуйте еще раз");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();  
        }
    }
}
