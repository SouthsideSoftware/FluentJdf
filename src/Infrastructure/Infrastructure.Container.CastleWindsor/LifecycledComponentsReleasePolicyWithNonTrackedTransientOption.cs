using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel;
using Castle.MicroKernel.Releasers;

namespace Infrastructure.Container.CastleWindsor
{
    /// <summary>
    /// Tracks transients only if they are not marked with the NonTrackedTransientLifestyle
    /// </summary>
    [Serializable]
    public class LifecycledComponentsReleasePolicyWithNonTrackedTransientOption : LifecycledComponentsReleasePolicy
    {
        private readonly Type nonTrackedTransientLifestyleType = typeof(NonTrackedTransientLifestyle);

        /// <summary>
        /// Tracks if needed.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="burden"></param>
        public override void Track(object instance, Burden burden)
        {
            if (nonTrackedTransientLifestyleType.Equals(burden.Model.CustomLifestyle))
            {
                return;
            }
            base.Track(instance, burden);
        }
    }
}
