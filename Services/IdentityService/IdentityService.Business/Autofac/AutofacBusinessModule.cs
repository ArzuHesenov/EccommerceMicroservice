using Autofac;
using IdentityService.Business.Abstract;
using IdentityService.Business.Concrete;
using IdentityService.DataAccess.Abstract;
using IdentityService.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
        
    }
}
