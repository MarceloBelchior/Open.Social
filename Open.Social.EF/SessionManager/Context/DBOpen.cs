using Microsoft.EntityFrameworkCore;
using Open.Social.EF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.EF.SessionManager.Context
{
   public class DBOpen : DbContext
    {
        public DbContext DbContext;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "data source=(localdb)\\mssqllocaldb;initial catalog=DBOpen;integrated security=True;MultipleActiveResultSets=True;ConnectRetryCount=0");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(
                entity =>
                {
                    entity.ToTable("Tbo_User","dbo");
                    entity.HasIndex(c => c.Id).IsUnique();
                    entity.Property(c => c.email).HasColumnName("email").HasMaxLength(150);
                    entity.Property(c => c.salt).HasColumnName("salt").HasMaxLength(60);
                    entity.Property(c => c.password).HasColumnName("password").HasMaxLength(150);
                });
            //modelBuilder.Entity<Customer>(
            //    entity =>
            //    {
            //        entity.ToTable("Customer", "Sales");

            //        entity.HasIndex(e => e.AccountNumber)
            //            .HasName("AK_Customer_AccountNumber")
            //            .IsUnique();

            //        entity.HasIndex(e => e.TerritoryID)
            //            .HasName("IX_Customer_TerritoryID");

            //        entity.HasIndex(e => e.rowguid)
            //            .HasName("AK_Customer_rowguid")
            //            .IsUnique();

            //        entity.Property(e => e.AccountNumber)
            //            .IsRequired()
            //            .HasColumnType("varchar(10)")
            //            .ValueGeneratedOnAddOrUpdate();

            //        entity.Property(e => e.ModifiedDate)
            //            .HasColumnType("datetime")
            //            .HasDefaultValueSql("getdate()");

            //        entity.Property(e => e.rowguid).HasDefaultValueSql("newid()");
            //    });
        }

        //public virtual DbSet<> Customers { get; set; }
    }
}