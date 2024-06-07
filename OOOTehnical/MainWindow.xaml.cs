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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace OOOTehnical
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string StatusConnection = "Подключение ...";

        public void connect()
        {
            SqlConnection conn = new 
                SqlConnection("Data Source=DESKTOP-UL9Q5UH\\MISHASQL;Initial Catalog=TehnicalService;User ID=sa;Password=123");
            conn.Open();
            StatusConnection = conn.State.ToString();
            conn.Close();
        }

        public MainWindow()
        {
            InitializeComponent();
            connect();
            tbConnectionShow.Text = StatusConnection;
        }

        private void btRegistraion_Click(object sender, RoutedEventArgs e)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.Show();
            this.Close();
        }

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
