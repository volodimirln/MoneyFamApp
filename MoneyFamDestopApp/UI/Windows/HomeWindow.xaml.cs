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
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public static User user {  get; set; }
        public HomeWindow(User usr)
        {
            InitializeComponent();
            user = usr;
            MainFrame.Navigate(new UI.Pages.Home.HomePage());
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Home.HomePage());
        }

        private void btnFanily_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Family.WelcomeFamilyPage());
        }

        private void btnTarget_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Target.TargetPage());
        }

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
           if( MessageBox.Show("Вы уверены, что хотите выйти из учетной записи?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
				AuthWindow authWnd = new AuthWindow();
				authWnd.Show();
				this.Close();
			}
		}
	}
}
