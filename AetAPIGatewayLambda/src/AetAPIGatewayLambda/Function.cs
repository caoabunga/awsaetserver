using System;
using System.Net;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
// This uses the new 3.1 serializer, more trimmed down than previous package..
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AETServer
{
    public class ElgibilityFunctions
    {
        /// <summary>
        /// Web response via Amazon API Gateway 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse Get( APIGatewayProxyRequest request, ILambdaContext context)
        {

            LogMessage(context, "Processing request started");
            Console.WriteLine("console write line test API TEST");

            APIGatewayProxyResponse response;
            try
            {
                var result = DateTime.UtcNow;
                response = CreateResponse(result);

            }
            catch (Exception ex)
            {
                LogMessage(context, string.Format("Processing request failed - {0}", ex.Message));
                response = CreateResponse(null);
            }

            return response;
        }

        APIGatewayProxyResponse CreateResponse(DateTime? result)
        {
            int statusCode = (result != null) ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;

            string body = (result != null) ? JsonConvert.SerializeObject(result) : string.Empty;

            var response = new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = body,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*" }
                }
            };

            return response;
        }

        /// <summary>
        /// Simple lambda function that takes a POCO and returns a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns>generic string</returns>
        public string FunctionHandler(NewUser input, ILambdaContext context)
        {

            LogMessage(context, "A different logger");
            LambdaLogger.Log("Start FunctionHandler calls!!!!");
            Console.WriteLine("console write line test");
            // LambdaLogger.Log($"Calling function name: {context.FunctionName}\\n  {input.surname.ToUpper()}");
            // return $"Welcome dude: {input.firstName.ToUpper()} {input.surname} Your dog: {input.dogname}";
            return $"Generic response from FunctionHandler: {input} ";
            // return input?.ToUpper();
        }

        void LogMessage(ILambdaContext ctx, string msg)
        {
            ctx.Logger.LogLine(
                string.Format("{0}:{1} - {2}",
                    ctx.AwsRequestId,
                    ctx.FunctionName,
                    msg));
        }
    }
}