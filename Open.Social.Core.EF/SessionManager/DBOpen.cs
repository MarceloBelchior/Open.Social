using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.EF.SessionManager
{
   public class DBOpen : DbContext
    {
        public DBOpen() : base(GetOptions("Server=(localdb)\\mssqllocaldb;Database=DBOpen2;Trusted_Connection=True;MultipleActiveResultSets=true"))
        {
            
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<Model.User.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Model.User.User>(c =>
            {
                c.ToTable("Tbo_User");
                c.Property(u => u.id).HasColumnName("UserID").ValueGeneratedOnAdd();
                c.HasKey(u => u.id);
                c.Property(u => u.name).HasColumnName("name").HasMaxLength(150);
                c.Ignore(u => u.CodData);
                c.Ignore(u => u.ValidData);
                c.Ignore(u => u.Message);
                
            });
            //dotnet ef database update
            //dotnet ef migrations add InitialCreate
            //modelBuilder.Entity("AspCore_NovoDB.Models.Post", b =>
            //{
            //    b.Property<int>("PostId")
            //        .ValueGeneratedOnAdd();

            //    b.Property<int>("BlogId");

            //    b.Property<string>("Conteudo");

            //    b.Property<string>("Titulo");

            //    b.HasKey("PostId");

            //    b.HasIndex("BlogId");

            //    b.ToTable("Posts");
            //});
        }
        //public DbSet<OpenSquare.Model.TimeSheet.TimeSheet> TimeSheet { get; set; }

    }
}
