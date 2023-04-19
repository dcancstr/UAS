using AutoMapper;
using UAS.Application.Dto.Rol;
using UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName;
using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Features.Commands.Role.AddPersonelRol;
using UAS.Application.Features.Queries.Role.UpdatePersonelRolGetUsers;

namespace UAS.Application.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<GetMenupanelsWithUserNameQueryRequest, GetRoleMenuByUserName>().ReverseMap();
            CreateMap<GetMenupanelsWithUserNameQueryResponse, GetRoleMenuByUserNameResponse>().ReverseMap();
            CreateMap<CreateRoleAssignMenu, MenuPanel>().ReverseMap();
            CreateMap<UpdateRoleAssignMenu, MenuPanel>().ReverseMap();
            CreateMap<UpdateRoleAssignMenuGetRoles, PersonelRolTip>().ReverseMap();
            CreateMap<MenuKategori, GetMenuKategories>().ReverseMap();
            CreateMap<AddPersonelRolCommandRequest, AddPersonelRol>().ReverseMap();

        }
    }
}
