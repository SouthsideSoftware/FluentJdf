using Castle.Windsor;
using Infrastructure.Core.Container;
using Machine.Specifications;

namespace Infrastructure.Container.CastleWindsor.Tests.Unit.WindsorServiceLocator
{
    public class when_resolving_single_registered_component_by_type
    {
        static IServiceLocator serviceLocator;
        static ITest test;

        Establish context = () =>
                                {
                                    serviceLocator =
                                        new CastleWindsor.WindsorServiceLocator(new WindsorContainer());
                                    serviceLocator.Register(typeof (ITest), typeof (Test));
                                };

        Because of = () => test = serviceLocator.Resolve<ITest>();

        It should_have_resolved_an_instance = () => test.ShouldNotBeNull();

        It should_return_hello_when_called = () => test.Hello().ShouldEqual("hello");
    }

    public interface ITest
    {
        string Hello();
    }

    public class Test : ITest
    {
        #region ITest Members

        public string Hello()
        {
            return "hello";
        }

        #endregion
    }
}