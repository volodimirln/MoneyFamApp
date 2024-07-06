using MoneyFamDestopApp.Data.Models;
using System.Windows;
using System.Windows.Controls;


namespace MoneyFamDestopApp.UI.UserControllers
{
    /// <summary>
    /// Логика взаимодействия для TargetFamUC.xaml
    /// </summary>
    public partial class TargetFamUC : UserControl
    {
        public static readonly DependencyProperty dependency = DependencyProperty.Register("item", typeof(Goal), typeof(TargetFamUC),
                new PropertyMetadata(default(Goal)));

        public Goal item { get { return (Goal)GetValue(dependency); } set { SetValue(dependency, value); } }

        public TargetFamUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lblDate.Content = item.DateRegistration.ToString("dd.MM.yyyy");
                lblTitle.Text = item.Title;
                lblDescription.Text = item.Description;
                lblUser.Text = item.User.Surname + " " + item.User.Name[0] + ". " + item.User.Patronymic[0]+".";
                lblAmount.Content = " /" + item.AmountDouble.ToString("C2");
                lblCurrentCount.Content = item.CurrentCount.ToString("C2");
            }
            catch { }
        }
    }
}
