using System;
using FluentJdf.Configuration;
using Infrastructure.Container.CastleWindsor;
using Infrastructure.Logging.NLog;
using Machine.Specifications;

namespace FluentJdf.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Infrastructure.Core.Configuration.Settings.UseCastleWindsor().LogWithNLog().Configure();
            Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
        }

        public void OnAssemblyComplete() {}

        #endregion

        public void AfterContextCleanup() {
            Configuration.FluentJdfLibrary.Settings.ResetToDefaults();
        }
    }
}