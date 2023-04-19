using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.RedisCache;

namespace UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus
{
    public class RedisGetUserMenusQueryHandler : IRequestHandler<RedisGetUserMenusQueryRequest, RedisGetUserMenusQueryResponse>
    {
        private readonly IRedisCacheService _redisService;
        public RedisGetUserMenusQueryHandler(IRedisCacheService redisService)
        {
            _redisService = redisService;
        }
        public async Task<RedisGetUserMenusQueryResponse> Handle(RedisGetUserMenusQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _redisService.GetFromRedis<Dto.RedisCache.RedisGetUserMenus>(request.UserName + "_menus");
            if (result != null)
                return new() { MenuKategories = result.MenuKategories, MenuPanels = result.MenuPanels };
            else
                return null;
        }

    }
}
