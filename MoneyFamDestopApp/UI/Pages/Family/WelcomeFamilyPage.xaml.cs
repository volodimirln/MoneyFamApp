using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
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

namespace MoneyFamDestopApp.UI.Pages.Family
{
    /// <summary>
    /// Логика взаимодействия для WelcomeFamilyPage.xaml
    /// </summary>
    public partial class WelcomeFamilyPage : Page
    {
        public WelcomeFamilyPage()
        {
            InitializeComponent();
            if (Model.GetContext().FamilyMembers.Where(p => p.UserId == HomeWindow.user.Id).Count() > 0 || Model.GetContext().Families.Where(p => p.UserId == HomeWindow.user.Id).Count() > 0)
            {
                MainFrame.Navigate(new FamilyPage());
            }
        }

        private void btnCreateFamily_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.GetContext().Families.Add(new Data.Models.Family() { Title = "Семья " +
                    HomeWindow.user.Surname, UserId = HomeWindow.user.Id, DateRegistration = DateTime.Now, IsActive = true, SecretKey = CreateMD5(DateTime.Now + "123utirjfkdjfn") });
                Model.GetContext().SaveChanges();
                MainFrame.Navigate(new FamilyPage());
            }
            catch { MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public static string CreateMD5(string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }

        }

        private void btnSearchFamily_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.Models.Family family = Model.GetContext().Families.FirstOrDefault(p => p.IsActive == true && p.SecretKey == tbxTitle.Text);
                if (family != null)
                {
                    Model.GetContext().FamilyMembers.Add(new Data.Models.FamilyMember() { UserId = HomeWindow.user.Id, FamilyId = family.Id });
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Ваша семья найдена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainFrame.Navigate(new FamilyPage());
                }
                else
                {
                    MessageBox.Show("Указан неверный ключ", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch { MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
