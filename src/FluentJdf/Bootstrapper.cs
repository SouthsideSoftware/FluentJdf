using Onpoint.Commons.Core;
using Onpoint.Commons.Core.CastleWindsor;
using Onpoint.Commons.Logging.NLog;

namespace FluentJdf
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
