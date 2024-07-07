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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
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
            
                try
                {
                if (Model.GetContext().Users.FirstOrDefault(p => p.Login == tbxLogin.Text) == null)
                {
                    User user = new User()
                    {
                        Surname = tbxSurname.Text,
                        Name = tbxName.Text,
                        Patronymic = tbxPatronymic.Text,
                        Login = tbxLogin.Text,
                        Password = password
                    };
                    Model.GetContext().Users.Add(user);
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    new AuthWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
                }
                catch
                {
                    MessageBox.Show("Неверно введены данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
           
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

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
            AuthWindow authWnd = new AuthWindow();
            authWnd.Show();
            this.Close();
		}
	}
}
