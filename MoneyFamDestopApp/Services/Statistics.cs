using MoneyFamDestopApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFamDestopApp.Services
{
    public class Statistics
    {
        public static double GetStatisticTarget(int userId, DateTime date)
        {
            List<Goal> temp = Model.GetContex().Goals.Where(p => p.UserId == userId).ToList();
            List<Goal> result = new List<Goal>();
            foreach(Goal item in temp)
            {
                DateTime dt = (DateTime)item.DateRegistration;
                if (DateTime.Compare( new DateTime(date.Year, date.Month, 1), dt) > 0)
                {
                    result.Add(item);
                }

            }
            return result.Count();
        }
        public static double GetStatisticPayment(int userId, DateTime date)
        {
            List<Payment> temp = Model.GetContex().Payments.Where(p => p.Goal.User.Id == userId).ToList();
            List<Payment> result = new List<Payment>();
            foreach(Payment item in temp)
            {
                DateTime dt = (DateTime)item.DatePayment;
                if (item.IsDone)
                {
                    if (DateTime.Compare(dt, new DateTime(date.Year, date.Month, 1)) > 0)
                    {
                        if (DateTime.Compare(new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 1), dt) > 0)
                        {
                            result.Add(item);
                        }
                    }
                }
                    
            }

            return result.Count();
        }
        public static double GetStatisticMonth(int userId, DateTime date)
        {
            double amount = 0;
            try
            {
                List<Operation> temp = Model.GetContex().Operations.Where(p => p.UserId == userId).ToList();
                List<Operation> result = new List<Operation>();
                foreach (Operation item in temp)
                {
                    DateTime dt = (DateTime)item.DateCompletion;
                    if (dt != null)
                    {
                        if (DateTime.Compare(dt, new DateTime(date.Year, date.Month, 1)) > 0)
                        {
                            if (DateTime.Compare(new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 1), dt) > 0)
                            {
                                result.Add(item);
                            }
                        }
                    }

                }


                amount = result.Sum(p => p.Amount);
                return amount;
            }
            catch
            {
                return 0;
            }
        }
    }
}
