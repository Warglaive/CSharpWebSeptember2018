﻿using SIS.Framework.Api;
using SIS.Framework.Services;
using Torshia.Web.Services;
using Torshia.Web.Services.Contracts;

namespace Torshia.Web
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();
            dependencyContainer.RegisterDependency<ITasksService, TasksService>();
        }
    }
}