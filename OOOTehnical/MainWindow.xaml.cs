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
using System.Data;

namespace OOOTehnical
{
    public partial class MainWindow : Window
    {
        string StatusConnection = "Подключение ...";

        public MainWindow()
        {
            InitializeComponent();
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
            try
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataTable dt = new DataTable();
                string command = "select * from [dbo].[user] where [login] = '{0}' and [password] = '{1}'";
                command = string.Format(command, tbLogin.Text, tbPassword.Text);
                dt = dataBaseClass.read(command);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Успешная авторизация под " + dt.Rows[0][2], "ООО Техническое", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    MessageBox.Show("Неверный логин или пароль", "ООО Техническое", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
