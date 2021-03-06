﻿using Dotnet.Samples.RESTful.Data;
using Dotnet.Samples.RESTful.Services;
using Dotnet.Samples.RESTful.Services.Mocks;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Dotnet.Samples.RESTful.Api
{
    internal static class SimpleInjectorConfiguration
    {
        internal static void Configure()
        {
            var container = new Container();

            container.Register<IRepository<Book>, BookRepository>(Lifestyle.Singleton);
#if DEBUG
            container.Register<IBookService, BookServiceMock>(Lifestyle.Singleton);
#else
            container.Register<IBookService, BookService>(Lifestyle.Singleton);
#endif
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}