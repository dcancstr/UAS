using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UAS.Application.Abstractions.Services;

namespace UAS.UI.CustomAuthorize
{
    public class AllowedControllersRequirement : IAuthorizationRequirement
    {
        public List<string> AllowedControllers { get; }

        public AllowedControllersRequirement(List<string> allowedControllers)
        {
            AllowedControllers = allowedControllers;
        }
    }
}
