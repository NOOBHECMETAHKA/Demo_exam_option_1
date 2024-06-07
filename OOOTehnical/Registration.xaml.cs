using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace OOOTehnical
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                string command = "insert [dbo].[user] ([login], [password], [role]) values('{0}', '{1}', '{2}')";
                command = string.Format(command, tbLogin.Text, tbPassword.Text, "user");
                dataBaseClass.execute(command);
                MessageBox.Show("Успешная регистрация", "ООО Техническое", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
