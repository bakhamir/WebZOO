using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        //private string _key = "DenFAo9tyF6AQarP6OpBcB1iBhjSvBITFweCkbHg";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _str = "https://localhost:7120/Login?login=";
                string _url = _str + tbLogin.Text + "&password=" + tbPassword.Text;
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(_url);
                    if (response != null)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        if (json == "true")
                        {
                            AuthPage authPage = new AuthPage();
                            this.Close();
                            authPage.Show();
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
            SignInPage signInPage = new SignInPage();
            this.Close();
            signInPage.Show();
        }




        //public async void GetAllUsersFromDB()
        //{
        //    try
        //    {
        //        string _url = "https://localhost:7120/GetAllUsers";
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = await client.GetAsync(_url);
        //            if (response != null)
        //            {
        //                var json = await response.Content.ReadAsStringAsync();
        //                List<Users> res = JsonConvert.DeserializeObject<List<Users>>(json);
        //                MessageBox.Show(res.Count.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        //public async void GetTestData()
        //{
        //    try
        //    {
        //        string _url = "https://localhost:7120/GetData";
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = await client.GetAsync(_url);
        //            if (response != null)
        //            {
        //                var json = await response.Content.ReadAsStringAsync();
        //                MessageBox.Show(json);
        //            }
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        //public async void GetWeatherForecast()
        //{
        //    try
        //    {
        //        string _url = "https://localhost:7120/WeatherForecast";
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = await client.GetAsync(_url);
        //            if (response != null)
        //            {
        //                var json = await response.Content.ReadAsStringAsync();
        //                MessageBox.Show(json);
        //            }
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        //public async void sendNasaApi()
        //{
        //    try
        //    {
        //        string _url = "https://api.nasa.gov/planetary/apod?api_key=" + _key;
        //        using (HttpClient client = new HttpClient())
        //        {
        //            var response = await client.GetAsync(_url);
        //            if (response != null)
        //            {
        //                var json = await response.Content.ReadAsStringAsync();
        //                NasaResponse res = JsonConvert.DeserializeObject<NasaResponse>(json);
        //                MessageBox.Show(res.Explanation);
        //            }
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}
    }
}
