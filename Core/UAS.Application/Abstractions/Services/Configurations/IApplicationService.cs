using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Configuration;

namespace UAS.Application.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
        /// <summary>
        /// Rol bazinda yetki kontrolu yapilacak sekilde isaretlenmis olan tum endpointleri getirir, liste halinde ve menu tipinde return eder.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
