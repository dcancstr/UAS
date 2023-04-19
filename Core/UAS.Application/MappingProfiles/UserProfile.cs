using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.User;
using UAS.Application.Features.Commands.AppUser.CreateUser;
using UAS.Application.Features.Commands.AppUser.DeleteUser;
using UAS.Application.Features.Commands.AppUser.DeleteUserPermanent;
using UAS.Application.Features.Commands.AppUser.RestoreUser;
using UAS.Application.Features.Commands.AppUser.UpdateUser;
using UAS.Application.Features.Commands.AppUser.UpdateUser.UpdateUserFromMyProfile;
using UAS.Application.Features.Queries.AppUser.GetUserByUserName;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.Application.MappingProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommandRequest, CreateUser>().ReverseMap();
            CreateMap<CreateUser, AppUser>().ReverseMap();
            CreateMap<IResult, CreateUserCommandResponse>().ReverseMap();
            CreateMap<GetUserResponse, AppUser>().ReverseMap();
            CreateMap<DeleteUserCommandRequest, DeleteUser>().ReverseMap();
            CreateMap<IResult, DeleteUserCommandResponse>().ReverseMap();
            CreateMap<IResult, GetUserByUserNameQueryResponse>().ReverseMap();
            CreateMap<UpdateUserCommandRequest, UpdateUser>().ReverseMap();
            CreateMap<UpdateUserFromMyProfileCommandRequest,UpdateUserMyProfile>().ReverseMap();
            CreateMap<IResult, UpdateUserCommandResponse>().ReverseMap();
            CreateMap<DeleteUserPermanentCommandRequest, DeleteUser>().ReverseMap();
            CreateMap<IResult, DeleteUserPermanentCommandResponse>().ReverseMap();
            CreateMap<RestoreUserCommandRequest, RestoreUser>().ReverseMap(); 
            CreateMap<IResult, RestoreUserCommandResponse>().ReverseMap();
            CreateMap<UpdateUser, AppUser>().ReverseMap();  
            CreateMap<UpdateUserFromMyProfileCommandRequest, AppUser>().ReverseMap();
        }
    }
}
