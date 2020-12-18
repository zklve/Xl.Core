using Autofac;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;
namespace Xl.Core.API.Modules
{
    public class NetCoreAutoFacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //环保服务
            builder.RegisterAssemblyTypes(Assembly.Load("Xl.Core.HbService"))
               .Where(x => x.Name.EndsWith("Impl")).AsImplementedInterfaces();

            //环保应用
            builder.RegisterAssemblyTypes(Assembly.Load("XL.Core.Application"))
               .Where(x => x.Name.EndsWith("Impl")).AsImplementedInterfaces();

            //环保仓储
            builder.RegisterAssemblyTypes(Assembly.Load("Xl.Core.Repository"))
               .Where(x => x.Name.EndsWith("Impl")).AsImplementedInterfaces();


        }
    }
}
