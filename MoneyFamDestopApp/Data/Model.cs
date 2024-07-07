using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoneyFamDestopApp.Data.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelApp")
        {
        }

        private static Model _context;
        public static Model GetContext()
        {
            if (_context == null)
                _context = new Model();
            return _context;
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Operations)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Family>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Family>()
                .Property(e => e.SecretKey)
                .IsUnicode(false);

            modelBuilder.Entity<Family>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.Family)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Goal>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Goal>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Goal>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Goal>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Goal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operation>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FamilyMembers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Goals)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Operations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
