using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            myTextBlock.Text = "123";

            WebClient client = new WebClient();
            //client.BaseAddress = "https://api.nasa.gov/planetary/apods";
            //client.QueryString.Add("hd", "True");
            //client.QueryString.Add("api_key","");

            using (Stream stream = client.OpenRead("https://api.nasa.gov/planetary/apods?hd=True"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string data = reader.ReadToEnd();
                    NasaImageResponse response = jsonConvert.Deserialize(data);
                    client.DownloadFile(response.Hduri, "image.jpg");
                    //вставляем в наш WPF
                }
            }

        }
    }
}