using System.Data.Entity;
using Autofac;
using AspNetMvcArch.Domain;
using AspNetMvcArch.Repository;

namespace AspNetMvcArch.Modules
{


    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(AspNetMvcArchContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();         
        }

    }
}