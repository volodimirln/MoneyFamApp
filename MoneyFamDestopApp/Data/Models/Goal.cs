namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Goal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goal()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(70)]
        public string Title { get; set; }
        [NotMapped]
        public string TitleString { get{ return "Операция на цель: " + Title; } }

        [Required]
        [StringLength(350)]
        public string Description { get; set; }

        public bool IsFamily { get; set; }

        [Required]
        [StringLength(70)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRegistration { get; set; }

        public int? Amount { get; set; }

        [NotMapped]
        public double AmountDouble { get { return Math.Round(Convert.ToDouble(Amount) + 0.001, 2); } }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [NotMapped]
        public double CurrentCount { get

            {
                try
                {
                    return Math.Round(Convert.ToDouble(Model.GetContext().Payments.Where(p => p.IsDone == true && p.GoalId == Id).Sum(p => p.Amount)), 2);
                }
                catch
                {
                    return 0;
                }
            } }
    }
}
