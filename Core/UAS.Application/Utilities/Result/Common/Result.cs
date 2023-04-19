namespace UAS.Application.Utilities.Result.Common
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; set; }

        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string? message) : this(success)
        {
            Message = message;
        }
    }
}
