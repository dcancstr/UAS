using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Storage;
using UAS.Application.Repositories;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Commands.SiteSetting.RemoveSiteSetting
{
    public class DeleteSiteSettingCommandHandler : IRequestHandler<DeleteSiteSettingCommandRequest, DeleteSiteSettingCommandResponse>
    {
        readonly ISiteSettingReadRepository _siteSettingReadRepository;
        readonly ISiteSettingWriteRepository _siteSettingWriteRepository;
        readonly IStorageService _storageService;

        public DeleteSiteSettingCommandHandler(ISiteSettingReadRepository siteSettingReadRepository, ISiteSettingWriteRepository siteSettingWriteRepository, IStorageService storageService)
        {
            _siteSettingReadRepository = siteSettingReadRepository;
            _siteSettingWriteRepository = siteSettingWriteRepository;
            _storageService = storageService;
        }

        public async Task<DeleteSiteSettingCommandResponse> Handle(DeleteSiteSettingCommandRequest request, CancellationToken cancellationToken)
        {
            await _siteSettingWriteRepository.RemoveAsync(request.Id);
            Domain.Entities.SiteSetting? siteSetting = _siteSettingReadRepository.Table.FirstOrDefault(s => s.Id == request.Id);

            if (siteSetting != null)
            {
                _storageService.DeleteAsync(siteSetting.LogoUrl, siteSetting.LayoutImageUrl, siteSetting.SiteName);
            }
            await _siteSettingWriteRepository.SaveAsync();

            return new();
        }
    }
}
