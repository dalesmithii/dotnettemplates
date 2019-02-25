using Autofac;
using ServiceName.Domain.Aggregates;
using ServiceName.Infrastructure.Repositories;

namespace ServiceName.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleRepository>()
                .As<ISampleRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
