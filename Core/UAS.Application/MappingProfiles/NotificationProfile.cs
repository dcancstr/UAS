using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Notification.CreateNotification;
using UAS.Application.Dto.Notification.GetNotification;
using UAS.Application.Dto.Notification.RemoveNotification;
using UAS.Application.Dto.Notification.UpdateNotification;
using UAS.Application.Features.Commands.Notification.CreateNotificationCommand;
using UAS.Application.Features.Commands.Notification.RemoveNotificationCommand;
using UAS.Application.Features.Commands.Notification.UpdateNotificationCommand;
using UAS.Application.Features.Queries.Notification.GetAllNotification;
using UAS.Application.Features.Queries.Notification.GetByIdNotification;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.Application.MappingProfiles
{
    internal class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<CreateNotificationCommandRequest, CreateNotification>().ReverseMap();
            CreateMap<CreateNotification, Notification>().ReverseMap();
            CreateMap<IResult, CreateNotificationCommandResponse>().ReverseMap();

            CreateMap<UpdateNotificationCommandRequest, UpdateNotification>().ReverseMap();
            CreateMap<UpdateNotification, Notification>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<IResult, UpdateNotificationCommandResponse>().ReverseMap();

            CreateMap<GetByIdNotificationQueryRequest, GetByIdNotification>().ReverseMap();
            CreateMap<GetByIdNotificationResponse, GetByIdNotificationQueryResponse>().ReverseMap();

            CreateMap<Notification, GetByIdNotificationResponse>().ReverseMap();
            CreateMap<GetAllNotificationResponse, GetAllNotificationQueryResponse>().ReverseMap();

            CreateMap<RemoveNotificationCommandRequest, RemoveNotification>().ReverseMap();
            CreateMap<IResult, RemoveNotificationCommandResponse>().ReverseMap();
        }
    }
}
