using MoneyFamDestopApp.Data.Models;
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

namespace MoneyFamDestopApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string password = "";
            if (chShowPassword.IsChecked != null)
            {
                if (chShowPassword.IsChecked == true)
                {
                    password = tbxPassword.Text;
                }
                else
                {
                    password = pswPassword.Password;
                }
            }
            else
            {
                password = pswPassword.Password;
            }

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(tbxLogin.Text))
            {
               
                    User user = Model.GetContex().Users.FirstOrDefault(p => p.Login == tbxLogin.Text);
                    if (user != null && user.Password == password)
                    {
						MessageBox.Show("Добро пожаловать!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
						new HomeWindow(user).Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Указаны неверный пароль или несуществующая почта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Указаны не все данные");
                }

            
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
           new RegistrationWindow().Show();
            this.Close();
        }

        private void chShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (chShowPassword.IsChecked != null)
            {
                if (chShowPassword.IsChecked == true)
                {
                    tbxPassword.Text = pswPassword.Password;
                    pswPassword.Visibility = Visibility.Collapsed;
                }
                else
                {
                    pswPassword.Password = tbxPassword.Text;
                    pswPassword.Visibility = Visibility.Visible;
                }
            }
        }

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
            Environment.Exit(0);
		}
	}
}
