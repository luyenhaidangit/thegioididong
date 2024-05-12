namespace Thegioididong.Api.Models.Responses
{
    public class ApiValidationErrorResponse<T>
    {
        public bool Status { get; set; }

        public string? Message { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}
