using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jdp.Jdf.LinqToJdf.Configuration;
using Onpoint.Commons.Core;
using Onpoint.Commons.Core.CastleWindsor;
using Onpoint.Commons.Logging.NLog;

namespace Jdp.Jdf
{
    /// <summary>
    /// Used to initialize logging and DI container.
    /// </summary>
    public static class Bootstrapper {
        static bool isInitialized = false;

        /// <summary>
        /// Call this to initialize logging and DI container
        /// </summary>
        public static void Initialize() {
            if (!isInitialized) {
                Configuration.Instance.UseCastleWindsor().LogWithNLog().Configure();
                isInitialized = true;
            }
        }
    }
}
