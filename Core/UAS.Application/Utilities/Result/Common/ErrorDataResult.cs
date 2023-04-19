namespace UAS.Application.Utilities.Result.Common
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult() : base(default, false)
        {

        }
        public ErrorDataResult(TData data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(false, message)
        {

        }
        public ErrorDataResult(TData data, string message) : base(data, false, message)
        {

        }
    }
}
