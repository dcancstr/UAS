using System.Collections.Generic;

namespace UAS.Application.Utilities.Result.Common
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }
        public ErrorResult(string message) : base(false, message)
        {
            
        }
    }
}
