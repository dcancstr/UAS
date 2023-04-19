using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus
{
    public class RedisGetUserMenusQueryRequest : IRequest<RedisGetUserMenusQueryResponse>
    {
        public string UserName { get; set; }

    }
}
