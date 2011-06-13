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
                Infrastructure.Core.Configuration.Instance.Configure();
                isInitialized = true;
            }
        }
    }
}
