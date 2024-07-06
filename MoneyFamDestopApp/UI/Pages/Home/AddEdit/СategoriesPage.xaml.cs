using MoneyFamDestopApp.Data;
using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MoneyFamDestopApp.UI.Pages.Home.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для СategoriesPage.xaml
    /// </summary>
    public partial class СategoriesPage : Page
    {
        public СategoriesPage()
        {
            InitializeComponent();
            btnDel.Visibility = Visibility.Collapsed;
            lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count() / 5));
            if (Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id || p.UserId == null).Count() > 5)
            {
                lblCount.Content = "5 из " + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count();
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }
            lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Take(5).ToList();
        }

        public int take = 5;
        public int skip = 0;

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            skip -= 5;
            if (skip >= 0)
            {
                lblCount.Content = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Skip(skip).Take(take).Count() +
                    " из " + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count();
                lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count() / 5));
            }
            else
            {
                skip = 0;
                lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            skip += 5;
            List<Category> item = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).ToList().Skip(skip).Take(take).ToList();
            if (item.Count != 0)
            {
                lsvItems.ItemsSource = item;
                lblCount.Content = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Skip(skip).Take(take).Count() +
                    " из " + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + Model.GetContex().Categories.Where(p => p.UserId == HomeWindow.user.Id && p.Active == true || p.UserId == null).Count() / 5));
            }
            else
            {
                skip -= 5;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsvItems.SelectedItem == null)
                {
                    btnDel.Visibility = Visibility.Collapsed;
                    Category item = new Category()
                    {

                        UserId = HomeWindow.user.Id,
                        Title = tbxTitle.Text,
                        Active = true,
                        DateRegistration = DateTime.Now
                    };
                    Model.GetContex().Categories.Add(item);
                    Model.GetContex().SaveChanges();
                    MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Take(5).ToList();
                    tbxTitle.Text = "";
                }
                else
                {
                    Category item = (lsvItems.SelectedItem as Category);
                    if (item.UserId == HomeWindow.user.Id)
                    {
                        btnDel.Visibility = Visibility.Visible;
                        item.Title = tbxTitle.Text;
                        Model.GetContex().Categories.AddOrUpdate(item);
                        Model.GetContex().SaveChanges();
                        MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Take(5).ToList();
                        tbxTitle.Text = "";
                    }
                }
               
            }
            catch
            {
                MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category item = (lsvItems.SelectedItem as Category);
            if (item != null)
            {
                if (item.UserId == HomeWindow.user.Id)
                {
                    tbxTitle.Text = item.Title;
                    btnDel.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что вы хотите отключить категорию?", "Отключение категории", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
           {
               try
               {
                   Category item = (lsvItems.SelectedItem as Category);
                   item.Active = false;
                   Model.GetContex().Categories.AddOrUpdate(item);
                   Model.GetContex().SaveChanges();
                   MessageBox.Show("Категория перенесена в архив", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                   lsvItems.ItemsSource = Model.GetContex().Categories.Where(p => (p.UserId == null || p.UserId == HomeWindow.user.Id) && p.Active == true).OrderByDescending(p => p.Id).Take(5).ToList();
               }
               catch
               {
                   MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
               }
           }
        }
    }
}
