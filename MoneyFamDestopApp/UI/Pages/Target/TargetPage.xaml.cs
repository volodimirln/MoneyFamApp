using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyFamDestopApp.UI.Pages.Target
{
    /// <summary>
    /// Логика взаимодействия для TargetPage.xaml
    /// </summary>
    public partial class TargetPage : Page
    {
        private int count = 0;
        public TargetPage()
        {
            InitializeComponent();
            lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).Count() / 5));
            List<Goal> item = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Take(6).ToList();
                if (item.Count > 0)
            {
                lblEmpty.Visibility = Visibility.Collapsed;
                lsvGoals.ItemsSource = item;
			}
            else
            {
                lsvGoals.Visibility = Visibility.Collapsed;
            }
            if (Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Count()  > 6)
            {
                lblCount.Content = item.Count + " из " + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Count();
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }

            btnDelete.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((lsvGoals.SelectedItem as Goal) == null)
            {
                try
                {
                    bool isfamily = false;
                    if (cmbItem.SelectedIndex == 0)
                    {
                        isfamily = true;
                    }
                    Goal item = new Goal()
                    {
                        UserId = HomeWindow.user.Id,
                        Title = tbxTitle.Text,
                        Description = tbxDescription.Text,
                        IsFamily = isfamily,
                        Type = tbxType.Text,
                        Amount = Convert.ToInt32(tbxAmount.Text),
                        DateRegistration = DateTime.Now
                    };
                    Model.GetContext().Goals.Add(item);
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsvGoals.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
                    tbxTitle.Text = "";
                    tbxAmount.Text = "";
                    tbxDescription.Text = "";
                    tbxType.Text = "";
                    cmbItem.SelectedItem = null;
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                
                    bool isfamily = false;
                    if (cmbItem.SelectedIndex == 0)
                    {
                        isfamily = true;
                    }
                    int id = (lsvGoals.SelectedItem as Goal).Id;
                    Goal item = Model.GetContext().Goals.FirstOrDefault(p => p.Id == id);

       
                        item.UserId = HomeWindow.user.Id;
                        item.Title = tbxTitle.Text;
                        item.Description = tbxDescription.Text;
                        item.IsFamily = isfamily;
                        item.Type = tbxType.Text;
                        item.Amount = Convert.ToInt32(tbxAmount.Text);
                    
                    Model.GetContext().Goals.AddOrUpdate(item);
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsvGoals.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
                    tbxTitle.Text = "";
                    tbxAmount.Text = "";
                    tbxDescription.Text = "";
                    tbxType.Text = "";
                }
              
            
            
        
        }
        public int take = 6;
        public int skip = 0;
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            skip -= 6;
            if (skip >= 0)
            {
                lsvGoals.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
                lblCount.Content = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Skip(skip).Take(take).Count() +
                    " из " + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Count();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).Count() / 5));
            }
            else
            {
                skip = 0;
                lsvGoals.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            skip += 6;
            List<Goal> item = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList().Skip(skip).Take(take).ToList();
            lblCount.Content = item.Count + " из " + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Count();
            lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).Count() / 5));
            if (item.Count != 0)
            {
                lsvGoals.ItemsSource = item;
            }
            else
            {
                skip -= 6;
            }
        }


        private void lsvGoals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnDelete.Visibility = Visibility.Visible;
                if ((lsvGoals.SelectedItem as Goal) != null)
                {
                tbxTitle.Text = (lsvGoals.SelectedItem as Goal).Title;
                tbxAmount.Text = (lsvGoals.SelectedItem as Goal).Amount.ToString();
                tbxDescription.Text = (lsvGoals.SelectedItem as Goal).Description;
                tbxType.Text = (lsvGoals.SelectedItem as Goal).Type;
                if ((lsvGoals.SelectedItem as Goal).IsFamily == true)
                {
                    cmbItem.SelectedIndex = 0;
                }
                else
                {
                    cmbItem.SelectedIndex = 1;
                }
                }
                
            }
            catch { }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что вы хотите удалить цель?", "Удалить цель", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    Goal item = (lsvGoals.SelectedItem as Goal);

                    Model.GetContext().Goals.Remove(item);
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Цель удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsvGoals.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка, по целе имеются операции!", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void tbxAmount_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cmbItemPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
