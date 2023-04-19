using MediatR;
using UAS.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.AppUser.GetUserByUserName
{
    public class GetUserByUserNameQueryRequest : IRequest<GetUserByUserNameQueryResponse>
    {
        public GetUser GetUser { get; set; }
    }
}
