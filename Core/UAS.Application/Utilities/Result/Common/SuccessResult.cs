using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Utilities.Result.Common
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }
        public SuccessResult(string message) : base(true, message)
        {

        }
    }
}
