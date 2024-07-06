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

namespace MoneyFamDestopApp.UI.UserControllers
{
    /// <summary>
    /// Логика взаимодействия для TargetUC.xaml
    /// </summary>
    public partial class TargetUC : UserControl
    {
        public static readonly DependencyProperty dependency = DependencyProperty.Register
            ("item", typeof(Goal), typeof(TargetUC),
                new PropertyMetadata(default(Goal)));

        public Goal item { get { return (Goal)GetValue(dependency); } set
            { SetValue(dependency, value); } }
        public TargetUC()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (item.IsFamily)
                {
                    System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.
                        Media.ColorConverter.ConvertFromString("#179DE3");
                    SolidColorBrush brush = new SolidColorBrush(color);
                    brdStatus.Background = brush;
                    lblSatatus.Content = " семья";
                }
                else
                {
                    System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.
                        Media.ColorConverter.ConvertFromString("#F44336");
                    SolidColorBrush brush = new SolidColorBrush(color);
                    brdStatus.Background = brush;
                    lblSatatus.Content = "личная";
                }
                lblDate.Content = item.DateRegistration.ToString("dd.MM.yyyy");
                lblTitle.Text = item.Title;
                lblDescription.Text = item.Description;
                lblUser.Text = HomeWindow.user.Surname + " " + HomeWindow.user.Name[0] 
                    + ". " + HomeWindow.user.Patronymic[0] 
                    + ".";
                lblAmount.Content = " /" + item.AmountDouble.ToString("C2");
                lblCurrentCount.Content = item.CurrentCount.ToString("C2");
            }
            catch { }
        }
    }
}
