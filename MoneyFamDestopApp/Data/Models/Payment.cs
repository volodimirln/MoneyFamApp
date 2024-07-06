namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Media;

    public partial class Payment
    {
        public int Id { get; set; }
        [NotMapped]
        public string AmountString { get { return AmountDouble.ToString("C2") + " за месяц"; } set { } }
        public int GoalId { get; set; }
        public int? IsYield { get; set; }

        public DateTime? DateExecution { get; set; }
        
        [NotMapped]
        public string AmountStr { get { return AmountDouble.ToString("C2"); } }
        public DateTime DatePayment { get; set; }
        [NotMapped]
        public string DatePaymentStr { get { 
                    return DatePayment.ToString("dd.MM.yyyy"); } }

        public int? PeriodInHours { get; set; }

        public bool IsDone { get; set; }

        public int Amount { get; set; }
        [NotMapped]
        public double AmountDouble { get { return Math.Round(Convert.ToDouble(Amount), 2); } }

        public virtual Goal Goal { get; set; }

        [NotMapped]
        public Brush Clr 
        {
            //2KMB852KMB85 new SolidColorBrush(Colors.Red);
            get
            {
                if (IsYield == 0 || IsYield == null)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.Green);
                }
            }
        }

        [NotMapped]
        public string CtType
        {
            get
            {
                if (IsYield == 0 || IsYield == null)
                {
                    return "расход";
                }
                else
                {
                    return "приход";
                }
            }
        }

        [NotMapped]
        public string CompletePayment
        {
            get
            {
                if (IsDone)
                {
                    return "Выполнен";
                }
                else
                {
                    return "Не выполнен";
                }
            }
        }
    }
}
