using Newtonsoft.Json;
using System;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Resolvers;

namespace Thegioididong.Api.Middlewares
{
    public class BadRequestHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public BadRequestHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using var originalBodyStream = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
                await HandleBadRequestResponse(context, memoryStream);
            }

            // Reset the stream and write back to the original response
            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBodyStream);
        }

        private async Task HandleBadRequestResponse(HttpContext context, MemoryStream memoryStream)
        {
            // Write response
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver(),
                Formatting = Formatting.Indented
            };

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            var errorResponse = JsonConvert.DeserializeObject<ValidationError>(responseBody);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var firstErrorKey = errorResponse.Errors.Keys.First();

            var result = new ApiValidationErrorResponse<Dictionary<string,string>>
            {
                Status = false,
                Message = errorResponse.Errors[firstErrorKey].First(),
                Errors = errorResponse.Errors,
            };

            var jsonErrorResponse = JsonConvert.SerializeObject(result, settings);

            // Write the modified response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(jsonErrorResponse);

            // Reset memory stream after modifying it
            memoryStream.SetLength(0);
            var responseBytes = System.Text.Encoding.UTF8.GetBytes(jsonErrorResponse);
            await memoryStream.WriteAsync(responseBytes, 0, responseBytes.Length);

            // Reset the position for copying back to the original stream
            memoryStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
