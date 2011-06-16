using System;
using Infrastructure.Core;
using Infrastructure.Logging.NLog;
using NUnit.Framework;

[SetUpFixture]
public class SetUpFixture {
    [SetUp]
    public void SetUp() {
        Configuration.Settings.LogWithNLog().Configure();
    }
}