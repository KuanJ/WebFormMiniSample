using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AccountingNote.ORM.DBModels
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnectionString")
        {
        }

        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounting>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.PWD)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<UserRoles>()
                .HasMany(e => e.UserRoles1)
                .WithRequired(e => e.UserRoles2)
                .HasForeignKey(e => e.UserInfoID);
        }
    }
}
