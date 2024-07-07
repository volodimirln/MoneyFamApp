using MoneyFamDestopApp.Data;
using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MoneyFamDestopApp.UI.Pages.Home.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для SpendingPage.xaml
    /// </summary>
    public partial class SpendingPage : Page
    {
        public DateTime period = DateTime.Now;

        public SpendingPage()
        {
            InitializeComponent();
			List<Operation> item = DatePeriodViewModel.GetOperationList(DateTime.Now).OrderByDescending(p => p.Id).Take(6).ToList();
			if (item.Count > 0)
			{
				lblEmpty.Visibility = Visibility.Collapsed;
				lsvItems.ItemsSource = item;
			}
			else
			{
				lsvItems.Visibility = Visibility.Collapsed;
			}
			if (DatePeriodViewModel.GetOperationList(DateTime.Now).Count() > 5)
            {
                lblCount.Content = "5 из " + DatePeriodViewModel.GetOperationList(DateTime.Now).Count();
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }
            //lblPtriod.Content = "с 01." + DateTime.Now.ToString("MM") + " по 01." + DateTime.Now.AddMonths(1).ToString("MM");
            lsvItems.ItemsSource = DatePeriodViewModel.GetOperationList(DateTime.Now).OrderByDescending(p => p.Id).Take(5).ToList();
            cmbItem.ItemsSource = Model.GetContext().Categories.Where(p => p.UserId == null || p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
            List<DatePeriod> period = new List<DatePeriod>();
            period.Add(new DatePeriod() { DateTime = DateTime.Now });
            period.Add(new DatePeriod() { DateTime = DateTime.Now.AddMonths(-1) });
            period.Add(new DatePeriod() { DateTime = DateTime.Now.AddMonths(-2) });
            cmbItemPeriod.ItemsSource = period;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Operation item = new Operation()
                {
                    Amount = Convert.ToInt32(tbxAmount.Text),
                    CategoryId = (cmbItem.SelectedItem as Category).Id,
                    UserId = HomeWindow.user.Id,
                    Note = tbxTitle.Text,
                    DateCompletion = DateTime.Now
                };
                Model.GetContext().Operations.Add(item);
                Model.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                lsvItems.ItemsSource = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Take(5).ToList();
                tbxTitle.Text = "";
                tbxAmount.Text = "";
                cmbItem.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удалить запись", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                try
                {
                    Model.GetContext().Operations.Remove((lsvItems.SelectedItem as Operation));
                    Model.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    lsvItems.ItemsSource = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Take(5).ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        public int take = 5;
        public int skip = 0;

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            skip -= 5;
            if (skip >= 0)
            {
                lblCount.Content = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Skip(skip).Take(take).Count() +
                    " из " + DatePeriodViewModel.GetOperationList(period).Count();
                lsvItems.ItemsSource = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + (DatePeriodViewModel.GetOperationList(period).Count() / 5)));
            }
            else
            {
                skip = 0;
                lsvItems.ItemsSource = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Skip(skip).Take(take).ToList();
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            skip += 5;
            List<Operation> item = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).ToList().Skip(skip).Take(take).ToList();
            if (item.Count != 0)
            {
                lsvItems.ItemsSource = item;
                lblCount.Content = DatePeriodViewModel.GetOperationList(period).OrderByDescending(p => p.Id).Skip(skip).Take(take).Count() +
                    " из " + DatePeriodViewModel.GetOperationList(period).Count();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + (DatePeriodViewModel.GetOperationList(period).Count() / 5)));
            }
            else
            {
                skip -= 5;
            }
        }

        private void tbxAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cmbItemPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            period = (cmbItemPeriod.SelectedItem as DatePeriod).DateTime;
            decimal all = DatePeriodViewModel.GetOperationList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count();
            lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(all / 5);

            if (DatePeriodViewModel.GetOperationList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count() > 5)
            {
                lblCount.Content = "5 из " + DatePeriodViewModel.GetOperationList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count();

                img1.Visibility = Visibility.Visible;
                img2.Visibility = Visibility.Visible;
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }
            List<Operation> item = DatePeriodViewModel.GetOperationList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Take(5).ToList();
            if (item.Count > 0)
            {
                lblEmpty.Visibility = Visibility.Collapsed;
                lsvItems.ItemsSource = item;
            }
            else
            {
                lsvItems.Visibility = Visibility.Collapsed;
            }
        }
    }
    
}
