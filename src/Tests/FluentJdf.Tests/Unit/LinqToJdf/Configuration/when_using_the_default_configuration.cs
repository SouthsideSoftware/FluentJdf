﻿using FluentJdf.LinqToJdf.Configuration;
using Machine.Specifications;
using Onpoint.Commons.Core.Helpers;

namespace FluentJdf.Tests.Unit.LinqToJdf.Configuration
{
    [Subject(typeof(JdpLibrary))]
    public class when_using_the_default_configuration {
        It should_have_agent_name_same_as_application_name = () => JdpLibrary.Settings.AgentName.ShouldEqual(ApplicationInformation.Name);

        It should_have_author_same_as_application_name = () => JdpLibrary.Settings.Author.ShouldEqual(ApplicationInformation.Name);

        It should_have_agent_version_same_as_application_version = () => JdpLibrary.Settings.AgentVersion.ShouldEqual(ApplicationInformation.Version);

        It should_have_option_to_create_audit_on_ticket_create_on = () => JdpLibrary.Settings.AddCreateAuditOnNewRootJdf.ShouldBeTrue();
    }
}