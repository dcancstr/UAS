using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Rol;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Queries.Role.GetPersonelRolTips
{
    public class GetPersonelRolTipsQueryResponse
    {
        public List<GetPersonelRolTip> Data { get; set; }
    }
}
