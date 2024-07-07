using LiveCharts.Defaults;
using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoneyFamDestopApp.UI.Windows;
using LiveCharts.Wpf;

namespace MoneyFamDestopApp.UI.UserControllers
{
    /// <summary>
    /// Логика взаимодействия для StatisticsUC.xaml
    /// </summary>
    public partial class StatisticsUC : UserControl
    {
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        private List<Payment> payment = Model.GetContext().Payments.Where(p => p.Goal.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Take(5).ToList();
        private ChartValues<ObservablePoint> observablePoints = new ChartValues<ObservablePoint>();
        public StatisticsUC()
        {
            InitializeComponent();
            foreach (var item in payment)
            {
                observablePoints.Add(new ObservablePoint(item.Id, item.Amount));
            }

            SeriesCollection = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                     Title = "Сумма операции - ",
                    Values = observablePoints,
                }
            };
            DataContext = this;
        }
    }
}
