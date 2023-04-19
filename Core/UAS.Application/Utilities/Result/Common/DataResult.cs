namespace UAS.Application.Utilities.Result.Common
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public DataResult(TData? data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(TData? data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(bool success, string message) : base(success, message)
        {

        }

        public TData? Data { get; set; }
    }
}
