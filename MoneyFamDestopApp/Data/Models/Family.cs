namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Family
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Family()
        {
            FamilyMembers = new HashSet<FamilyMember>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateRegistration { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(32)]
        public string SecretKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
