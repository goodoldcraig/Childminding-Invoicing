namespace ManageMyChild.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ManageMyChildModel : DbContext
    {
        public ManageMyChildModel()
            : base("name=ManageMyChildContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Children)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.CareerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.CareerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Parents)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.CareerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Child>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Child>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Child>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Child>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Child)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Child>()
                .HasMany(e => e.Parents)
                .WithMany(e => e.Children)
                .Map(m => m.ToTable("ParentChild").MapLeftKey("ChildId").MapRightKey("ParentId"));

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.Parents)
                .WithMany(e => e.Invoices)
                .Map(m => m.ToTable("ParentInvoice").MapLeftKey("InvoiceId").MapRightKey("ParentId"));

            modelBuilder.Entity<Parent>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
