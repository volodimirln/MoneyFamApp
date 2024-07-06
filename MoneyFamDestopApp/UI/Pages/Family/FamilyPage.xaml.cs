using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для FamilyPage.xaml
    /// </summary>
    public partial class FamilyPage : Page
    {
        public Data.Models.Family Family { get; set; }
        public FamilyPage()
        {
            InitializeComponent();
            if (Model.GetContex().Families.Where(p => p.UserId == HomeWindow.user.Id && p.IsActive == true).Count() > 0)
            {
                Family = Model.GetContex().Families.FirstOrDefault(p => p.UserId == HomeWindow.user.Id && p.IsActive == true);
            }
            else
            {
                if (Model.GetContex().FamilyMembers.Where(p => p.UserId == HomeWindow.user.Id && p.Family.IsActive == true).Count() > 0)
                {
                    Family = Model.GetContex().FamilyMembers.FirstOrDefault(p => p.UserId == HomeWindow.user.Id).Family;
                    tbxTitle.IsReadOnly = true;
                }
            }
            List<FamilyMember> member = Model.GetContex().FamilyMembers.Where(p => p.FamilyId == Family.Id).OrderByDescending(p => p.Id).ToList();
            List<User> user = new List<User>();
            foreach (FamilyMember mb in member)
            {
                user.Add(mb.User);
            }
            user.Add(Model.GetContex().Users.FirstOrDefault(p => p.Id == Family.UserId) );
            List<Goal> goals = Model.GetContex().Goals.Where(p => p.IsFamily == true).OrderByDescending(p => p.Id).ToList();
            List<Goal> ngoals = new List<Goal>();
            foreach (Goal gl in goals)
            {
                foreach (User uc in user)
                {
                    if (gl.UserId == uc.Id)
                    {
                        ngoals.Add(gl);
                    }
                }
            }
            lsvGoals.ItemsSource = ngoals.Take(3);
            lsvItems.ItemsSource = user.Take(3);
            lblCMembers.Content = user.Count() + " участ.";
            lblFamily.Content = Family.Title;
            tbxTitle.Text = Family.Title;
            tbxKey.Text = Family.SecretKey;
            string owner = Model.GetContex().Users.FirstOrDefault(p => p.Id == Family.UserId).FullName;
            lblOwner.Content = "Основатель семьи: " + owner;
            if (Family.IsActive)
            {
                cmbItem.SelectedIndex = 0;
            }
            else
            {
                cmbItem.SelectedIndex = 1;
            }
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                if (Family.UserId == HomeWindow.user.Id)
                {
                if (MessageBox.Show("Вы уверены, что вы хотите удалить пользователя из семьи?", "Удаление пользователя из семьи", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = (lsvItems.SelectedItem as User).Id;
                        FamilyMember mb = Model.GetContex().FamilyMembers.FirstOrDefault(p => p.FamilyId == Family.Id && p.UserId == id);
                        Model.GetContex().FamilyMembers.Remove(mb);
                        Model.GetContex().SaveChanges();
                        MessageBox.Show("Удален из семьи", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch { MessageBox.Show("Ошибка, вы не можете удалить самого себя!", "Информация", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Family.UserId == HomeWindow.user.Id)
            {
                try
                {
                    bool result = true;
                    if (cmbItem.SelectedIndex != 0)
                    {
                        result = false;
                    }
                    Family.Title = tbxTitle.Text;
                    Family.IsActive = result;
                    Model.GetContex().Families.AddOrUpdate(Family);
                    MessageBox.Show("Данные изменены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
