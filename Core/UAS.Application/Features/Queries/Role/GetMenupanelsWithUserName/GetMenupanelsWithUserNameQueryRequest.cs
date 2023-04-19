using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName
{
    public class GetMenupanelsWithUserNameQueryRequest : IRequest<GetMenupanelsWithUserNameQueryResponse>
    {
        public string UserName { get; set; }
    }
}
