using Machine.Specifications;

namespace Jdp.Jdf.Tests
{
    [Subject(typeof (Dummy))]
    public class when_running_a_dummy_test
    {
        It should_create_instance = () => new Dummy().ShouldNotBeNull();
    }
}