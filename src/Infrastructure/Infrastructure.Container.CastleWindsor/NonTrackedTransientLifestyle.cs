using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// A transient that is not tracked by the castle windsor container.
    /// </summary>
    [Serializable]
    public class NonTrackedTransientLifestyle : ILifestyleManager
    {
        private IComponentActivator componentActivator;

        /// <summary>
        /// Initalize the activator.
        /// </summary>
        /// <param name="componentActivator"></param>
        /// <param name="kernel"></param>
        /// <param name="model"></param>
        public void Init(IComponentActivator componentActivator, IKernel kernel, ComponentModel model)
        {
            this.componentActivator = componentActivator;
        }

        /// <summary>
        /// Resolve.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Resolve(CreationContext context)
        {
            return componentActivator.Create(context);
        }

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Release(object instance)
        {
            return true;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {

        }

    }
}
