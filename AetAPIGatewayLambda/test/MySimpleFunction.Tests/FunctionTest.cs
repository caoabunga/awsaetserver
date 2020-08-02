using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AETServer;

namespace AETServer.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new ElgibilityFunctions();
            var context = new TestLambdaContext();
            var newUser = new NewUser();
            newUser.firstName = "hello";
            var upperCase = function.FunctionHandler(newUser, context);

            Assert.Equal("Generic response from FunctionHandler: AETServer.NewUser ", upperCase);
        }
    }
}
