using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UAS.Application.Dto.Auth;
using UAS.Application.Dto.Token;
using UAS.Application.Utilities.Result.Common;

namespace UAS.Application.Abstractions.Services.Authentication
{
    public interface IInternalAuthService
    {
        Task<IDataResult<AccessToken>> LoginAsync(LoginUser loginUser);
        Task<IDataResult<AccessToken>> RefreshTokenLoginAsync(string refreshToken);
        Task LogOutAsync();
    }
}
