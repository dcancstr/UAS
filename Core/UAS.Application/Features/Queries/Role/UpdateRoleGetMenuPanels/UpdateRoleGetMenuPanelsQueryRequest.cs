﻿using MediatR;
using UAS.Application.Dto.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.UpdateRoleGetMenuPanels
{
    public class UpdateRoleGetMenuPanelsQueryRequest : IRequest<UpdateRoleGetMenuPanelsQueryResponse>
    { 
        public UpdateRoleAssignMenuListe UpdateRoleAssignMenuListe { get; set; }
    }
}
