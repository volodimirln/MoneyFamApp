using MoneyFamDestopApp.Data;
using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.Services;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace MoneyFamDestopApp.UI.Pages.Home
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            List<Goal> items = DatePeriodViewModel.GetGoalList(DateTime.Now);
            if(items.Count > 0){
                lblEmpty.Visibility = Visibility.Collapsed;
                lsvGoals.ItemsSource = items;

            }
            else
            {
                lsvGoals.Visibility = Visibility.Collapsed;
            }
            lblWelcome.Content = "Добро пожаловать, " + HomeWindow.user.Name + " " + HomeWindow.user.Patronymic;
            lsvEvent.ItemsSource = Model.GetContext().Payments.Where(p => p.Goal.User.Id == HomeWindow.user.Id && p.IsDone == false).OrderByDescending(p => p.DateExecution).Take(2).ToList();
            lblCountPayment.Content = Statistics.GetStatisticPayment(HomeWindow.user.Id , DateTime.Now);
            lblAmount.Content = Statistics.GetStatisticMonth(HomeWindow.user.Id, DateTime.Now).ToString("C2");
            lblTargetCount.Content = Statistics.GetStatisticTarget(HomeWindow.user.Id, DateTime.Now);
            //lblPtriod.Content = "с 01." + DateTime.Now.ToString("MM") + " по 01." + DateTime.Now.AddMonths(1).ToString("MM");
            List<DatePeriod> period = new List<DatePeriod>();
            period.Add(new DatePeriod() { DateTime = DateTime.Now });
            period.Add(new DatePeriod() { DateTime = DateTime.Now.AddMonths(-1) });
            period.Add(new DatePeriod() { DateTime = DateTime.Now.AddMonths(-2) });
            cmbItem.ItemsSource = period;
            cmbItemPeriod.ItemsSource = period;
        }
        
        private void btnPAyment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Home.AddEdit.PaymentsPage());
        }

        private void btnGoals_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Target.TargetPage());
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Home.AddEdit.SpendingPage());

        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UI.Pages.Home.AddEdit.СategoriesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintStatistics.PrintStatisticsFile(HomeWindow.user.Id);
        }

        private void cmbItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbItem.SelectedItem != null)
            {
                lblCountPayment.Content = Statistics.GetStatisticPayment(HomeWindow.user.Id, (cmbItem.SelectedItem as DatePeriod).DateTime);
                lblAmount.Content = Statistics.GetStatisticMonth(HomeWindow.user.Id, (cmbItem.SelectedItem as DatePeriod).DateTime).ToString("C2");
                lblTargetCount.Content = Statistics.GetStatisticTarget(HomeWindow.user.Id, (cmbItem.SelectedItem as DatePeriod).DateTime);
            }
        }

        private void cmbItemPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Goal> items = DatePeriodViewModel.GetGoalList((cmbItemPeriod.SelectedItem as DatePeriod).DateTime);

                lsvGoals.ItemsSource = items;
         
        }
    }
}
 