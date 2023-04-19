using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.RedisCache;
using UAS.Application.Features.Commands.RedisCommands.RedisSetUserMenus;
using UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus;
using UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName;

namespace UAS.Application.MappingProfiles
{
    public class RedisProfile : Profile
    {
        public RedisProfile()
        {
            CreateMap<RedisGetUserMenusQueryResponse, GetMenupanelsWithUserNameQueryResponse>().ReverseMap();
            CreateMap<RedisGetUserMenusQueryResponse, RedisGetUserMenus>().ReverseMap();
            CreateMap<RedisSetUserMenusCommandRequest, RedisGetUserMenus >();
        }
    }
}
