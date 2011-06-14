using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Tests.Legacy
{
    /// <summary>
    /// Provides legacy wrapper for NUnit assertions
    /// so that old code can work with minimum effort.
    /// </summary>
    public static class AssertionHelper
    {
        /// <summary>
        /// Throws exception if condition is not true.
        /// </summary>
        /// <param name="condition"></param>
        public static void IsTrue(bool condition)
        {
            NUnit.Framework.Assert.IsTrue(condition);
        }

        /// <summary>
        /// Throws exception with given message if condition is not true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="condition"></param>
        public static void IsTrue(string message, bool condition)
        {
            NUnit.Framework.Assert.IsTrue(condition, message);
        }

        /// <summary>
        /// Throws exception with given message if condition is not true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void IsTrue(bool condition, string message)
        {
            NUnit.Framework.Assert.IsTrue(condition, message);
        }
    }
}
