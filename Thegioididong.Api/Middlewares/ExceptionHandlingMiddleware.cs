using Newtonsoft.Json;
using Thegioididong.Api.Exceptions.Common;
using Thegioididong.Api.Models.Responses;
using Thegioididong.Api.Resolvers;

namespace Thegioididong.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver(),
                Formatting = Formatting.Indented
            };

            var statusCode = GetStatusCode(exception);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = statusCode;

            var result = new ApiExceptionResult<object>()
            {
                Status = false,
                Message = exception.Message,
                Exception = exception,
                Data = null
            };

            var jsonErrorResponse = JsonConvert.SerializeObject(result, settings);

            await context.Response.WriteAsync(jsonErrorResponse);
        }

        private static int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                case BadRequestException:
                    return StatusCodes.Status400BadRequest;

                case NotFoundException:
                    return StatusCodes.Status404NotFound;

                case FormatException:
                    return StatusCodes.Status422UnprocessableEntity;

                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }

        //private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        //public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        //    => _logger = logger;

        // public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        // {
        //     try
        //     {
        //         await next(context);
        //     }
        //     catch (Exception e)
        //     {
        //         //_logger.LogError(e, e.Message);

        //         await HandleExceptionAsync(context, e);
        //     }
        // }

        // private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        // {
        //     var statusCode = GetStatusCode(exception);

        //     //var response = new
        //     //{
        //     //    title = GetTitle(exception),
        //     //    status = statusCode,
        //     //    detail = exception.Message,
        //     //    errors = GetErrors(exception),
        //     //};

        //     var response = new ApiResult<object>
        //     {
        //         Status = false,
        //         Message = exception.Message,
        //         Data = exception
        //     };

        //     httpContext.Response.ContentType = "application/json";

        //     httpContext.Response.StatusCode = statusCode;

        //     await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        // }

        //private static string GetTitle(Exception exception) =>
        //exception switch
        //{
        //     //DomainException applicationException => applicationException.Title,
        //     _ => "Server Error"
        //};

        ////private static IReadOnlyCollection<DistributedSystem.Application.Exceptions.ValidationError> GetErrors(Exception exception)
        ////{
        ////     IReadOnlyCollection<DistributedSystem.Application.Exceptions.ValidationError> errors = null;

        ////     if (exception is DistributedSystem.Application.Exceptions.ValidationException validationException)
        ////     {
        ////         errors = validationException.Errors;
        ////     }

        ////     return errors;
        //// }
    }
}
