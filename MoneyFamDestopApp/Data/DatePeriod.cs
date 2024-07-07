using MoneyFamDestopApp.Data.Models;
using MoneyFamDestopApp.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFamDestopApp.Data
{
    public class DatePeriodViewModel
    {
        public static List<Goal> GetGoalList(DateTime date)
        {
            List<Goal> temp = Model.GetContext().Goals.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).Take(3).ToList();
            List<Goal> result = new List<Goal>();
            foreach (Goal item in temp)
            {
                DateTime dt = (DateTime)item.DateRegistration;
                if (DateTime.Compare(new DateTime(date.Year, date.Month, 1), dt) > 0)
                {
                    result.Add(item);
                }

            }
            return result;
        }

        public static List<Payment> GetPaymentList(DateTime date)
        {
            List<Payment> temp = Model.GetContext().Payments.Where(p => p.Goal.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
            List<Payment> result = new List<Payment>();
            foreach (Payment item in temp)
            {
                DateTime dt = (DateTime)item.DatePayment;
                if (DateTime.Compare(dt, new DateTime(date.Year, date.Month, 1)) > 0)
                {
                    if (DateTime.Compare(new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 1), dt) > 0)
                    {
                        result.Add(item);
                    }
                }

            }
            return result;
        }

        public static List<Operation> GetOperationList(DateTime date)
        {
            List<Operation> temp = Model.GetContext().Operations.Where(p => p.UserId == HomeWindow.user.Id).OrderByDescending(p => p.Id).ToList();
            List<Operation> result = new List<Operation>();
            foreach (Operation item in temp)
            {
                DateTime dt = (DateTime)item.DateCompletion;
                if (DateTime.Compare(dt, new DateTime(date.Year, date.Month, 1)) > 0)
                {
                    if (DateTime.Compare(new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 1), dt) > 0)
                    {
                        result.Add(item);
                    }
                }

            }
            return result;
        }
    }
    public class DatePeriod
    {
        public DateTime DateTime { get; set; }
        public string DateTimeFormat { get { return "с 1." + DateTime.ToString("MM") + " по 1." + DateTime.AddMonths(1).ToString("MM"); } }
    }
}
