using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Owin;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebStoryDoc.App_Start;
using WebStoryDoc.Controllers;
using WebStoryDoc.Models;
using WebStoryDoc.Models.Repositories;

[assembly: OwinStartup(typeof(Startup))]
namespace WebStoryDoc.App_Start
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];

            if (connectionString == null)
            {
                throw new Exception("Не найдена строка подключения");
            }

            //Создаем экземпляр контейнера для внедрения зависимостей
            var containerBuilder = new ContainerBuilder();

            //Регистрируем конфигурацию подключения к БД
            containerBuilder.Register(x =>
            {
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
                    .CurrentSessionContext("call");

                var conf = cfg.BuildConfiguration();
                var schemeExport = new SchemaUpdate(conf);

                schemeExport.Execute(true, true);

                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();

            //Регистрируем фабрику сессий
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest();

            //Регистрируем Контроллеры
            containerBuilder.RegisterControllers(Assembly.GetAssembly(typeof(HomeController)));

            //Регистрируем Репозитории
            var types = typeof(Person).Assembly.GetTypes();
            foreach (var type in types)
            {
                var serviceAttribute = type.GetCustomAttribute<ServiceAttribute>();
                if (serviceAttribute == null)
                {
                    continue;
                }
                containerBuilder.RegisterType(type).AsSelf();
            }

            //Регистрируем модуль Автофага
            containerBuilder.RegisterModule(new AutofacWebTypesModule());

            //Собираем контейнер
            var conteiner = containerBuilder.Build();

            //Подключаем сонтейнер Автофага вместо контейнера по-умолчанию
            DependencyResolver.SetResolver(new AutofacDependencyResolver(conteiner));
            app.UseAutofacMiddleware(conteiner);
        }
    }
}