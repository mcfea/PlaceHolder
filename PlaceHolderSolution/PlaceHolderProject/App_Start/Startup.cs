using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PlaceHolderProject.Repositories.Users;

namespace PlaceHolderProject.App_Start
{
    public class Startup
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // user repositories
            builder.Register(x => UserRepositoryFactory.GetUserRepository()).As<IUserRepository>().InstancePerRequest();

            // set resolver
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}