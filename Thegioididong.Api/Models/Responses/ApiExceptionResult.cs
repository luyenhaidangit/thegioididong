namespace Thegioididong.Api.Models.Responses
{
    public class ApiExceptionResult<T> : ApiResult<T>
    {
        public Exception Exception { get; set; }
    }
}
