using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Open.Social.EF.SessionManager.Context
{
    public class DBContext : DbContext
    {


        public DBContext() : base("")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<OpenSquare.Model.TimeSheet.TimeSheet> TimeSheet { get; set; }

        public DbSet<OpenSquare.Model.User.User> User { get; set; }

        public DbSet<OpenSquare.Model.User.Profile> Profile { get; set; }

        public DbSet<Model.User.Action> Action { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Model.User.Addresses> Addresses { get; set; }

        public DbSet<Model.User.City> City { get; set; }

        public DbSet<Model.User.State> State { get; set; }

        public DbSet<Model.Account.Account> Account { get; set; }

        public DbSet<Model.Account.AccountBalance> AccountBalance { get; set; }

        public DbSet<Model.WebSite.Contact> Contact { get; set; }

        public DbSet<Model.Account.ClassField> ClassField { get; set; }

        public DbSet<Model.Account.Bank> Bank { get; set; }

        public DbSet<Model.WebSite.File> File { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Mapping.UserMapping());
            //modelBuilder.Configurations.Add(new Mapping.ProfileMap());
            //modelBuilder.Configurations.Add(new Mapping.UserMap());
            //modelBuilder.Configurations.Add(new Mapping.UsuarioMap());
            //modelBuilder.Configurations.Add(new Mapping.AddressMap());
            //modelBuilder.Configurations.Add(new Mapping.CityMap());
            //modelBuilder.Configurations.Add(new Mapping.StateMap());
            //modelBuilder.Configurations.Add(new Mapping.AccountMap());
            //modelBuilder.Configurations.Add(new Mapping.AccountBalanceMap());
            //modelBuilder.Configurations.Add(new Mapping.ContactMap());
            //modelBuilder.Configurations.Add(new Mapping.ClassFieldMap());
            //modelBuilder.Configurations.Add(new Mapping.BankMap());
            //modelBuilder.Configurations.Add(new Mapping.AccountHoldMap());
            //modelBuilder.Configurations.Add(new Mapping.ActionMap());
            //modelBuilder.Configurations.Add(new Mapping.FileMap());


        }
    }
}