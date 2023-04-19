using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.User;
using UAS.Application.Features.Commands;
using UAS.Application.Utilities.Result.Common;

namespace UAS.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryResponse : CommandBaseResponse
    {
        public IDataResult<List<ListUser>>? Users { get; set; }
        public int TotalUsersCount { get; set; }

    }
}
