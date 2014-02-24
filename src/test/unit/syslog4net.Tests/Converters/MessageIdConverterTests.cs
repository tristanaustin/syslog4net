﻿using System.IO;
using log4net;
using log4net.Core;
using log4net.Util;
using syslog4net.Converters;
using NSubstitute;
using NUnit.Framework;
using syslog4net.Util;
using System;

namespace syslog4net.Tests.Converters
{
    [TestFixture]
    public class MessageIdConverterTests
    {
        [Test]
        public void ConvertTestStackData()
        {
            var testId = "9001";
            var writer = new StreamWriter(new MemoryStream());
            var converter = new MessageIdConverter();

            var log = Substitute.For<ILog>();
            log.StartMessage(testId);

            converter.Format(writer, new LoggingEvent(new LoggingEventData()));
            writer.Flush();

            var result = TestUtilities.GetStringFromStream(writer.BaseStream);

            Console.WriteLine("Actual: " + result);
            Console.WriteLine("Expected: " + testId);

            Assert.AreEqual(testId, result);
        }
    }
}