using MoneyFamDestopApp.Data;
using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для PaymentsPage.xaml
    /// </summary>
    public partial class PaymentsPage : Page
    {
        public DateTime period = DateTime.Now;

        public PaymentsPage()
        {
            InitializeComponent();
            lblPage.Content = "1/" + Math.Ceiling(Convert.ToDecimal(DatePeriodViewModel.GetPaymentList(DateTime.Now).Count()/5));
            if (DatePeriodViewModel.GetPaymentList(DateTime.Now).Count() > 5)
            {
                lblCount.Content = "5 из " + DatePeriodViewModel.GetPaymentList(DateTime.Now).Count();
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }
			List<Payment> item = DatePeriodViewModel.GetPaymentList(DateTime.Now).OrderBy(p => p.DateExecution).Take(5).ToList();
			if (item.Count > 0)
			{
				lblEmpty.Visibility = Visibility.Collapsed;
				lsvItems.ItemsSource = item;
			}
			else
			{
				lsvItems.Visibility = Visibility.Collapsed;
			}
			cmbItem.ItemsSource = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
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
                if ((cmbItem.SelectedItem as Goal) != null)
                {
                Payment item = new Payment()
                {
                    Amount = Convert.ToInt32(tbxAmount.Text),
                    GoalId = (cmbItem.SelectedItem as Goal).Id,
                    DatePayment = DateTime.Parse(tbxTitle.Text),
                    IsYield = cmbIsYield.SelectedIndex,
                    IsDone = false
                };
                Model.GetContext().Payments.Add(item);
                Model.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                lsvItems.ItemsSource = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).Take(5).ToList();
                tbxTitle.Text = "";
                tbxAmount.Text = "";
                cmbItem.SelectedItem = null;
                cmbIsYield.SelectedItem = null;
                }

            }
            catch
            {
                MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public int take = 5;
        public int skip = 0;
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            skip -= 5;
            if (skip >= 0)
            {
                lsvItems.ItemsSource = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).Skip(skip).Take(take).ToList();
                lblCount.Content = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).Skip(skip).Take(take).Count() +
                    " из " + DatePeriodViewModel.GetPaymentList(period).Count();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + (DatePeriodViewModel.GetPaymentList(period).Count() / 5)));

            }
            else
            {
                skip = 0;
                lsvItems.ItemsSource = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).Skip(skip).Take(take).ToList();
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(DatePeriodViewModel.GetPaymentList(period).Count() / 5));

            }

        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            skip += 5;
            List<Payment> item = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).ToList().Skip(skip).Take(take).ToList();
            if (item.Count != 0)
            {
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(1 + (DatePeriodViewModel.GetPaymentList(period).Count() / 5)));
                lsvItems.ItemsSource = item;
                lblCount.Content = DatePeriodViewModel.GetPaymentList(period).OrderBy(p => p.DateExecution).Skip(skip).Take(take).Count() +
                    " из " + DatePeriodViewModel.GetPaymentList(period).Count();
            }
            else
            {
                skip -= 5;
                lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling(Convert.ToDecimal(DatePeriodViewModel.GetPaymentList(period).Count() / 5));
            }
        }

        private void lsvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что вы выполнили операцию?", "Выполнение операции", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    Payment item = (lsvItems.SelectedItem as Payment);
                    if (item != null) {
                        if (item.DateExecution == null)
                        {
                            item.IsDone = true;
                            item.DateExecution = DateTime.Now;
                            Model.GetContext().Payments.AddOrUpdate(item);
                            Model.GetContext().SaveChanges();
                            MessageBox.Show("Операция выполнена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            lsvItems.ItemsSource = DatePeriodViewModel.GetPaymentList(period).OrderByDescending(p => p.Id).Take(5).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Операция выполнена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удалить запись", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
                            {
                                Model.GetContext().Payments.Remove((lsvItems.SelectedItem as Payment));
                                Model.GetContext().SaveChanges();
                                MessageBox.Show("Операция удалена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                lsvItems.ItemsSource = DatePeriodViewModel.GetPaymentList(period).OrderByDescending(p => p.Id).Take(5).ToList();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            decimal all = DatePeriodViewModel.GetPaymentList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count();
            lblPage.Content = Math.Ceiling(Convert.ToDecimal(skip / 5)) + 1 + "/" + Math.Ceiling( all/5);
            if (DatePeriodViewModel.GetPaymentList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count() > 5)
            {
                lblCount.Content = "5 из " + DatePeriodViewModel.GetPaymentList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).Count();

                img1.Visibility = Visibility.Visible;
                img2.Visibility = Visibility.Visible;
            }
            else
            {
                img1.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Collapsed;
                lblCount.Content = "       ";
            }
            List<Payment> item = DatePeriodViewModel.GetPaymentList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime).OrderBy(p => p.DateExecution).Take(5).ToList();
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
