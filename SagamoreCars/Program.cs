﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SagamoreCarsApiSDK;
using System;

namespace SagamoreCarsParser
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program");

            testSDKClient();//will be removed

            RegisterServices();

            var service = (IDemoService)_serviceProvider.GetService(typeof(IDemoService));
            service.StartSetupDB();

            Console.WriteLine("End of program");
        }

        //will be removed
        private static void testSDKClient()
        {
            var testClient = new SagamoreCarsApiClient();
            var allItems = testClient.GetAllAsync().Result;
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();
            builder.RegisterType<DemoService>().As<IDemoService>();
            builder.Populate(collection);
            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }
    }
}
