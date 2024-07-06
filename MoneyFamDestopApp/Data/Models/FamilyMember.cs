namespace MoneyFamDestopApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FamilyMember
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FamilyId { get; set; }

        public virtual Family Family { get; set; }

        public virtual User User { get; set; }
    }
}
