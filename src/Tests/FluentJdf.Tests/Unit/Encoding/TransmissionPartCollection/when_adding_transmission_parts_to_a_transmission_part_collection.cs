using System;
using FluentJdf.Encoding;
using Machine.Specifications;
using Rhino.Mocks;

namespace FluentJdf.Tests.Unit.Encoding.TransmissionPartCollection {
    [Subject(typeof (FluentJdf.Encoding.TransmissionPartCollection))]
    public class when_adding_transmission_parts_to_a_transmission_part_collection {
        It should_be_able_to_add_range_as_long_as_ids_are_unique = () => {
                                                                       var sourceTransmissionPartCollection =
                                                                           new FluentJdf.Encoding.TransmissionPartCollection();
                                                                       sourceTransmissionPartCollection.Add(GetMockTransmissionPart());
                                                                       sourceTransmissionPartCollection.Add(GetMockTransmissionPart());

                                                                       var transmissionPartCollection =
                                                                           new FluentJdf.Encoding.TransmissionPartCollection();
                                                                       transmissionPartCollection.AddRange(sourceTransmissionPartCollection);
                                                                       transmissionPartCollection.Count.ShouldEqual(2);
                                                                   };

        It should_be_able_to_add_the_first_transmission_part = () => {
                                                                   var transmissionPartCollection =
                                                                       new FluentJdf.Encoding.TransmissionPartCollection();
                                                                   transmissionPartCollection.Add(GetMockTransmissionPart());
                                                                   transmissionPartCollection.Count.ShouldEqual(1);
                                                               };

        It should_be_able_to_add_the_second_transmission_part_with_unqiue_id = () => {
                                                                                   var transmissionPartCollection =
                                                                                       new FluentJdf.Encoding.TransmissionPartCollection();
                                                                                   transmissionPartCollection.Add(GetMockTransmissionPart());
                                                                                   transmissionPartCollection.Add(GetMockTransmissionPart());
                                                                                   transmissionPartCollection.Count.ShouldEqual(2);
                                                                               };

        It should_fail_to_add_range_id_ids_are__not_unique = () => {
                                                                 var sourceTransmissionPartCollection =
                                                                     new FluentJdf.Encoding.TransmissionPartCollection();
                                                                 sourceTransmissionPartCollection.Add(GetMockTransmissionPart("1"));
                                                                 sourceTransmissionPartCollection.Add(GetMockTransmissionPart());

                                                                 var transmissionPartCollection =
                                                                     new FluentJdf.Encoding.TransmissionPartCollection();
                                                                 transmissionPartCollection.Add(GetMockTransmissionPart("1"));

                                                                 Catch.Exception(
                                                                     () => transmissionPartCollection.AddRange(sourceTransmissionPartCollection)).
                                                                     ShouldBe(typeof (ArgumentException));
                                                             };

        It should_fail_to_add_transmission_part_if_id_is_already_in_collection = () => {
                                                                                     var transmissionPartCollection =
                                                                                         new FluentJdf.Encoding.TransmissionPartCollection();
                                                                                     transmissionPartCollection.Add(GetMockTransmissionPart("1"));
                                                                                     Catch.Exception(
                                                                                         () =>
                                                                                         transmissionPartCollection.Add(GetMockTransmissionPart("1")))
                                                                                         .ShouldBe(typeof (ArgumentException));
                                                                                 };

        static ITransmissionPart GetMockTransmissionPart(string id = null) {
            var mock = MockRepository.GenerateStub<ITransmissionPart>();
            if (id == null) {
                id = Guid.NewGuid().ToString();
            }
            mock.Stub(m => m.Id).Return(id);
            return mock;
        }
    }
}