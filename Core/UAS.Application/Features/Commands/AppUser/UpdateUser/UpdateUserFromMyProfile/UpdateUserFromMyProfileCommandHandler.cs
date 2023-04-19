using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.AppUser.UpdateUser.UpdateUserFromMyProfile
{
    public class UpdateUserFromMyProfileCommandHandler : IRequestHandler<UpdateUserFromMyProfileCommandRequest, UpdateUserFromMyProfileCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public UpdateUserFromMyProfileCommandHandler(IUserService userService, IMapper mapper, IWebHostEnvironment env)
        {
            _userService = userService;
            _mapper = mapper;
            _env = env;
        }
        public async Task<UpdateUserFromMyProfileCommandResponse> Handle(UpdateUserFromMyProfileCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.PersonelImage != null)
            {
                var uploads = Path.Combine(_env.WebRootPath, "Uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (request.PersonelImage.ContentType.Contains("image"))
                {
                    if (request.PersonelImage.Length <= 2097152 && request.PersonelImage.Length > 0)
                    {
                        string uniqueName = $"{Guid.NewGuid().ToString().Replace("-", "_").ToLower()}.{request.PersonelImage.ContentType.Split('/')[1]}";
                        var filePath = Path.Combine(uploads, uniqueName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            request.PersonelImage.CopyTo(fileStream);

                            request.PersonelImageUrl = filePath.Substring(filePath.IndexOf("Uploads\\"));
                        }
                    }

                }


            }
            var url = _userService.GetById(request.Id).Result.PersonelImageUrl;
            var updateUser = _mapper.Map<Dto.User.UpdateUserMyProfile>(request);
            //updateUser.PersonelDogumYili = request.PersonelDogumYili;
            if (updateUser.PersonelImageUrl == null)
            {
                updateUser.PersonelImageUrl = url;
            }
            var result = await _userService.UpdateUserFormMyProfileAsync(updateUser);
            UpdateUserFromMyProfileCommandResponse updateUserCommandResponse = new();
            updateUserCommandResponse.Success = result.Success;
            updateUserCommandResponse.Message = result.Message;
            return updateUserCommandResponse;
        }
    }

}
