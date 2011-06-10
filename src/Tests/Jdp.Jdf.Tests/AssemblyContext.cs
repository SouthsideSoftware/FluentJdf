using System;
using Jdp.Jdf.LinqToJdf.Configuration;
using Machine.Specifications;

namespace Jdp.Jdf.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Bootstrapper.Initialize();
        }

        public void OnAssemblyComplete() {}

        #endregion

        public void AfterContextCleanup() {
            JdpLibrary.Settings.ResetToDefaults();
        }
    }
}