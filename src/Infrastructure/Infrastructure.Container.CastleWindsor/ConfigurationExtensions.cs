using System.Diagnostics.Contracts;
using Castle.Windsor;
using Infrastructure.Core;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// Extensions to the configuration.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Configure castle windsor as the container creating a new container.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration UseCastleWindsor(this Configuration configuration)
        {
            ParameterCheck.ParameterRequired(configuration, "configuration");

            var container = new WindsorContainer();
            return UseCastleWindsor(configuration, container);
        }

        /// <summary>
        /// Configure Castle Windsor as the container using an existing container.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static Configuration UseCastleWindsor(this Configuration configuration, IWindsorContainer container)
        {
            ParameterCheck.ParameterRequired(container, "container");
            ParameterCheck.ParameterRequired(configuration, "configuration");

            configuration.BuildWith(new WindsorServiceLocator(container));
            return configuration;
        }
    }
}
