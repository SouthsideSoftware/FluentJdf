using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Naming;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Infrastructure.Core.Logging;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// Extensions for Castle Windsor container
    /// </summary>
    public static class Extensions
    {
        static ILog logger;

        /// <summary>
        /// Use this in code so that the logger is not used until after
        /// the log provider is initialized by configuration.  Otherwise, you will always get 
        /// the null logger provider.
        /// </summary>
        static ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger(typeof (Extensions));
                }
                return logger;
            }
        }

        /// <summary>
        /// Register components in the calling assembly as singletons.
        /// </summary>
        /// <param name="container">The Windsor container.</param>
        /// <returns>The Windsor container.</returns>
        public static IWindsorContainer RegisterRemainingInterfaceImplementations(this IWindsorContainer container)
        {
            Contract.Requires(container != null);

            container.RegisterRemainingInterfaceImplementations(LifestyleType.Singleton, Assembly.GetCallingAssembly());
            return container;
        }

        /// <summary>
        /// Register components in the given assembly as singletons.
        /// </summary>
        /// <param name="container">The Windsor container.</param>
        /// <param name="assembly">The assembly</param>
        /// <returns>The Windsor container.</returns>
        public static IWindsorContainer RegisterRemainingInterfaceImplementations(this IWindsorContainer container,
                                                                                  Assembly assembly)
        {
            Contract.Requires(container != null);

            container.RegisterRemainingInterfaceImplementations(LifestyleType.Singleton, assembly);
            return container;
        }

        /// <summary>
        /// Register components in the given assembly with the given lifestyle.
        /// </summary>
        /// <param name="container">The Windsor container.</param>
        /// <param name="lifestyle">The desired lifestyle</param>
        /// <param name="assembly">The assembly</param>
        /// <returns>The Windsor container.</returns>
        public static IWindsorContainer RegisterRemainingInterfaceImplementations(this IWindsorContainer container,
                                                                                  LifestyleType lifestyle,
                                                                                  Assembly assembly = null)
        {
            Contract.Requires(container != null);

            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }
            container.Register(
                AllTypes.FromAssembly(assembly).Pick()
                    .Unless(t => t.GetInterfaces().Count() < 1)
                    .Configure(comp => comp.LifeStyle.Is(lifestyle))
                    .WithService.AllInterfaces().AllowMultipleMatches());

            return container;
        }

        /// <summary>
        /// Register components in the one or more assemblies
        /// as directed in each assembly's Windsor installer class.
        /// </summary>
        /// <param name="container">The Windsor container.</param>
        /// <param name="assemblies">One or more assemblies.</param>
        public static void InstallAssemblies(this IWindsorContainer container, params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                container.Install(FromAssembly.Instance(assembly));
            }
        }

        /// <summary>
        /// Register components in assemblies loaded via one or more assembly filters
        /// as directed in each assembly's Windsor installer class.
        /// </summary>
        /// <param name="container">The Windsor container.</param>
        /// <param name="assemblyFilters">One or more assembly filters</param>
        /// <returns>The Windsor container.</returns>
        public static IWindsorContainer LoadAndInstallAssemblies(this IWindsorContainer container,
                                                                 params AssemblyFilter[] assemblyFilters)
        {
            foreach (AssemblyFilter assemblyFilter in assemblyFilters)
            {
                container.Install(FromAssembly.InDirectory(assemblyFilter));
            }

            return container;
        }

        /// <summary>
        /// Log the registered components in the container.
        /// </summary>
        /// <param name="container">The container that has the component registry to be logged.</param>
        public static void LogRegisteredComponents(this IWindsorContainer container)
        {
            if (Logger.IsDebugEnabled)
            {
                var sb = new StringBuilder("COMPONENTS IN WINDSOR CONTAINER:\n");
                var naming = container.Kernel.GetSubSystem(SubSystemConstants.NamingKey) as
                             INamingSubSystem;
                sb.AppendFormat("\n\t{0,-120}{1, -50}{2,-15}{3}\n", "KEY", "INTERFACE", "LIFESTYLE", "CLASS");

                List<string> components =
                    naming.GetHandlers().Select(
                        handler =>
                        string.Format("\t{0,-120}{1,-50}{2,-15}{3}\n", handler.ComponentModel.Name, handler.Service.Name,
                                      handler.ComponentModel.LifestyleType,
                                      handler.ComponentModel.Implementation.FullName)).ToList();
                components.Sort();
                components.ForEach(c => sb.Append(c));
                sb.Append("****************************************************");
                Logger.Debug(sb.ToString());
            }
        }

        /// <summary>
        /// Gets a list of class full names that are registered with Windsor as an implementation
        /// of the given service type.
        /// </summary>
        /// <typeparam name="T">The service type.</typeparam>
        /// <param name="container">The Windsor container.</param>
        public static IList<string> GetClassesImplementing<T>(this IWindsorContainer container)
        {
            var naming = container.Kernel.GetSubSystem(SubSystemConstants.NamingKey) as
                         INamingSubSystem;
            return (from handler in naming.GetHandlers()
                    where handler.Service == typeof (T)
                    orderby handler.ComponentModel.Implementation.FullName
                    select handler.ComponentModel.Implementation.FullName).ToList();
        }
    }
}