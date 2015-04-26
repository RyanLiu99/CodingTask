using Generic.Config;
using Generic.Config.Unity;
using Generic.DataAccess;
using Microsoft.Practices.Unity;
using RyanLiu.CodingTask.Core;
using RyanLiu.CodingTask.Core.Contracts;
using RyanLiu.CodingTask.Web.Utilities;
using Survey.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RyanLiu.CodingTask.Web.App_Start
{
    internal class IocConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {            
            var config = new UnityConfiguration(container);
            CfgEnvironment.Configure(config);

            container.RegisterType<IDataRepository, CodingTaskDataRepository>();
            container.RegisterType<IInputFilesGenerator, InputFilesGenerator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IContentStorage, FileSystemCotentStorage>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEntitiesStorage, EntitiesStorage>(new ContainerControlledLifetimeManager());
            container.RegisterType<IOutputsSaver, OutputsDatabaseSaver>(new ContainerControlledLifetimeManager());            
        }
    }
}