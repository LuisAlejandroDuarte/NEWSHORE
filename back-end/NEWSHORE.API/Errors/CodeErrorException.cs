namespace NEWSHORE.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(int statusCode, string? msg = null, string? details = null) : base(statusCode, msg)
        {
            Details = details;
        }
    }
}
