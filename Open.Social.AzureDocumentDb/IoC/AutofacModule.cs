﻿using Autofac;
using Open.Social.AzureDocumentDb.Collection;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Manager;
using Open.Social.Core.Interface;
using Open.Social.Core.Model.config;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.IoC
{
    public partial class AutofacModule : Module
    {
        private const string TimeSheetCollection = "TimeSheetCollection";
        private const string UserCollection = "UserCollection";

        protected override void Load(ContainerBuilder builder)
        {
            //Instantiate the Client
            builder.RegisterType<AzureDocClient>().As<IAzureDocClient>().SingleInstance();

            //Instantiate the DB
            builder.Register<AzureDocDatabase>(c =>
            {
                var docClient = c.Resolve<IAzureDocClient>();
                docClient.InitializeClient(); //Initialize the client before IAzureDocDatabase is available

                return new AzureDocDatabase(docClient, c.Resolve<DocumentDbConfig>());
            }).As<IAzureDocDatabase>().SingleInstance();

            //Register a Task<IAzureDocDatabase> that will run it's InitializeDatabaseAsync method
            builder.Register(c => c.Resolve<IAzureDocDatabase>().InitializeDatabaseAsync()); 
            

            //Register a Task<ProductCollection> that will resolve Task<IAzureDocDatabase> and Initialize the collection
            builder.Register(async c =>
            {
                var collection = new TimeSheetCollection(await c.Resolve<Task<IAzureDocDatabase>>(), TimeSheetCollection);
                await collection.InitializeAsync();

                return collection;
            });

            builder.Register(async c =>
            {
                var collection = new UserCollection(await c.Resolve<Task<IAzureDocDatabase>>(), UserCollection);
                await collection.InitializeAsync();

                return collection;
            });
            builder.Register(async c =>
            {
                var collection = new PartnerCollection(await c.Resolve<Task<IAzureDocDatabase>>(), "PartnerCollection");
                await collection.InitializeAsync();

                return collection;
            });


            //Register a Task<CartCollection> that will resolve Task<IAzureDocDatabase> and Initialize the collection
            //builder.Register(async c =>
            //{
            //    var collection = new CartCollection(await c.Resolve<Task<IAzureDocDatabase>>(), CartCollectionName);
            //    await collection.InitializeAsync();

            //    return collection;
            //});

            builder.Register(c => c.Resolve<Task<TimeSheetCollection>>().Result).As<ITimeSheetCollection>().SingleInstance();
            builder.Register(c => c.Resolve<Task<UserCollection>>().Result).As<IUserCollection>().SingleInstance();
            builder.Register(c => c.Resolve<Task<PartnerCollection>>().Result).As<IPartnerCollection>().SingleInstance();
            //builder.Register(c => c.Resolve<Task<CartCollection>>().Result).As<ICartCollection>().SingleInstance();
            builder.RegisterType<PartnerManagerStore>().As<IPartnerManagerStore>().SingleInstance();
            builder.RegisterType<TimeSheetManagerStore>().As<ITimeSheetManagerStore>().SingleInstance();
            builder.RegisterType<UserManagerStore>().As<IUserManagerStore>().SingleInstance();
            //builder.RegisterType<CartStorageManager>().As<ICartStorage>().SingleInstance();
        }
    }
}
