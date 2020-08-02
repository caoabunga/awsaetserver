using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AETServer;
using Amazon.Lambda.APIGatewayEvents;

namespace AETServer.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function
            var function = new ElgibilityFunctions();
            var context = new TestLambdaContext();
            var newUser = new NewUser();
            newUser.firstName = "hello";
            var upperCase = function.FunctionHandler(newUser, context);

            Assert.Equal("Generic response from FunctionHandler: AETServer.NewUser ", upperCase);
        }

        [Fact]
        public void TestGetMethod()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            ElgibilityFunctions functions = new ElgibilityFunctions();

            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();
            response = functions.Get(request, context);
            Assert.Equal(200, response.StatusCode);
        }
    }
}
