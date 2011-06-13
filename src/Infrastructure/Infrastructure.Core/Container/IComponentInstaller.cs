namespace Infrastructure.Core.Container
{
    /// <summary>
    /// Interface for a component installer.
    /// </summary>
    public interface IComponentInstaller
    {
        /// <summary>
        /// Install components in the given service locator.
        /// </summary>
        /// <param name="serviceLocator"></param>
        void Install(IServiceLocator serviceLocator);
    }
}
