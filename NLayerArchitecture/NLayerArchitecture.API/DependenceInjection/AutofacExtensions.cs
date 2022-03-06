using Autofac;
using NLayerArchitecture.DAL.Modules;

namespace NLayerArchitecture.API.DependenceInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();

            return builder;
        }
    }
}
