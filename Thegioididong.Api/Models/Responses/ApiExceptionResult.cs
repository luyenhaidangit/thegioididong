﻿namespace Thegioididong.Api.Models.Responses
{
    public class ApiExceptionResult<T> : ApiResult<T>
    {
        public bool Status { get; set; }

        public string? Message { get; set; }

        public Exception Exception { get; set; }
    }
}