using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.AppUser.GetlDeletedUsers
{
    public class GetDeletedUsersQueryRequest : IRequest<GetDeletedUsersQueryResponse>
    {
    }
}
