namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Title { get; set; }

        public int? UserId { get; set; }

        public DateTime DateRegistration { get; set; }

        public bool Active { get; set; }

        public virtual User User { get; set; }

        [NotMapped]
        public string UserName { get 
            {
                if (User != null)
                {
                    return User.FullName;
                }
                else
                {
                    return "Общедоступно";
                }
            } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
