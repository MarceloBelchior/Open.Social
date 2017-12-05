using Autofac;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.Core.Model.config;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Open.Social.AzureDocumentDb.IoC
{
   public class AutofacModule : Module
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

                return new AzureDocDatabase(docClient, c.Resolve<documentDbConfig>());
            }).As<IAzureDocDatabase>().SingleInstance();

            //Register a Task<IAzureDocDatabase> that will run it's InitializeDatabaseAsync method
            builder.Register(c => c.Resolve<IAzureDocDatabase>().InitializeDatabaseAsync());

            //Register a Task<ProductCollection> that will resolve Task<IAzureDocDatabase> and Initialize the collection
            builder.Register(async c =>
            {
                var collection = new Times ProductCollection(await c.Resolve<Task<IAzureDocDatabase>>(), ProductCollectionName);
                await collection.InitializeAsync();

                return collection;
            });

            //Register a Task<CartCollection> that will resolve Task<IAzureDocDatabase> and Initialize the collection
            builder.Register(async c =>
            {
                var collection = new CartCollection(await c.Resolve<Task<IAzureDocDatabase>>(), CartCollectionName);
                await collection.InitializeAsync();

                return collection;
            });

            builder.Register(c => c.Resolve<Task<ProductCollection>>().Result).As<IProductCollection>().SingleInstance();
            builder.Register(c => c.Resolve<Task<CartCollection>>().Result).As<ICartCollection>().SingleInstance();

            builder.RegisterType<ProductStorageManager>().As<IProductStorage>().SingleInstance();
            builder.RegisterType<CartStorageManager>().As<ICartStorage>().SingleInstance();
        }
    }
}
