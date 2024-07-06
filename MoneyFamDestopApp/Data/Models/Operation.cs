namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operation
    {
        public int Id { get; set; }

        public int Amount { get; set; }


        public int CategoryId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Note { get; set; }

        public DateTime DateCompletion { get; set; }
        [NotMapped]
        public string DateCompletionStr { get { return DateCompletion.ToString("dd.MM.yyy"); } }
        [NotMapped]
        public string AmountStr { get { return AmountDouble.ToString("C2"); } }
        [NotMapped]
        public double AmountDouble { get { return Math.Round(Convert.ToDouble(Amount), 2); } }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }

    }
}
