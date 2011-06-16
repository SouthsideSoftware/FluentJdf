using FluentJdf.Configuration;
using Infrastructure.Container.CastleWindsor;
using Infrastructure.Logging.NLog;
using Machine.Specifications;

namespace FluentJdf.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Library.Settings.Infrastructure.UseCastleWindsor().LogWithNLog();
        }

        public void OnAssemblyComplete() {}

        #endregion

        public void AfterContextCleanup() {
            Library.Settings.ResetToDefaults();
        }
    }
}