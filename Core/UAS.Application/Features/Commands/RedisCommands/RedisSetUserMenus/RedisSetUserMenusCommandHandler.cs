using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.RedisCache;

namespace UAS.Application.Features.Commands.RedisCommands.RedisSetUserMenus
{
    public class RedisSetUserMenusCommandHandler : IRequestHandler<RedisSetUserMenusCommandRequest, RedisSetUserMenusCommandResponse>
    {
        private readonly IRedisCacheService _redisService;
        private readonly IMapper _mapper;
        public RedisSetUserMenusCommandHandler(IRedisCacheService redisService, IMapper mapper)
        {
            _mapper = mapper;
            _redisService = redisService;
        }
        public async Task<RedisSetUserMenusCommandResponse> Handle(RedisSetUserMenusCommandRequest request, CancellationToken cancellationToken)
        {
            var expiring = DateTimeOffset.Now.AddMinutes(30);
            var result = await _redisService.SetToRedis(request.UserName + "_menus", _mapper.Map<Dto.RedisCache.RedisGetUserMenus>(request), expiring);
            return new() { Success = result };
        }
    }
}
