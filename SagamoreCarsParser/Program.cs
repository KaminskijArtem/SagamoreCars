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

            RegisterServices();

            var service = (IImportService)_serviceProvider.GetService(typeof(IImportService));
            while (true)
            {
                service.StartSetupDB();
            }

            Console.WriteLine("End of program");
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var builder = new ContainerBuilder();
            builder.RegisterType<ImportService>().As<IImportService>();
            builder.Populate(collection);
            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }
    }
}
