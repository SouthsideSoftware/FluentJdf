using Machine.Specifications;

namespace Jdp.Jdf.Tests {
    public class AssemblyContext : IAssemblyContext {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Bootstrapper.Initialize();
        }

        public void OnAssemblyComplete() {}

        #endregion
    }
}