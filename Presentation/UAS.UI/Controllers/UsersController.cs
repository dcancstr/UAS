using MediatR;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ServiceStack;
using UAS.Application.Dto.User;
using UAS.Application.Features.Commands.AppUser.CreateUser;
using UAS.Application.Features.Queries.AppUser.GetAllUser;
using UAS.Application.Features.Queries.AppUser.GetlDeletedUsers;
using UAS.Application.Features.Queries.AppUser.GetUserById;
using UAS.Application.Features.Queries.AppUser.GetUserByUserName;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using X.PagedList;

namespace UAS.UI.Controllers
{
    public class UsersController : CustomBaseController
    {
        
        public UsersController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
        {
            var response = await base._mediator.Send(createUserCommandRequest);
            return RedirectToAction("Index", "Auth");
        }
        [HttpGet]
        public async Task<GetUserResponse> GetById(GetUserByIdQueryRequest getUserByIdQueryRequest)
        {
            var response = await base._mediator.Send(getUserByIdQueryRequest);
            return response.GetUserResponse;
        }
        [HttpGet]
        public async Task<JsonResult> GetAllJSON()
        {
            var response = await _mediator.Send(new GetAllUserQueryRequest());
            return Json(response.Users);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedJSON()
        {
            var response = await _mediator.Send(new GetDeletedUsersQueryRequest());
            return Json(response.Users);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(GetAllUserQueryRequest getAllUserQueryRequest)
        {
            var response = await base._mediator.Send(getAllUserQueryRequest);
            return View(response);
        }

        //public async Task<IActionResult> Search(string p, GetAllUserQueryRequest getAllUserQueryRequest)
        //{
        //    var response = await base._mediator.Send(getAllUserQueryRequest);
        //    IEnumerable<ListUser> result = null;
        //    //var values = response.Users.Data;
        //    if (!string.IsNullOrEmpty(p))
        //    {
        //         result = response.Users.Data.Where(x => x.UserName.Contains(p)||x.Name.Contains(p) || x.Surname.Contains(p) || x.Email.Contains(p));
        //    }
        //    return View(result);
        //}

        //public async Task<IActionResult> Paging(GetAllUserQueryRequest getAllUserQueryRequest, int? page)
        //{
        //    var pageNumber = page ?? 1;
        //    var response = await base._mediator.Send(getAllUserQueryRequest);
        //    ViewBag.values = response.Users.Data.ToPagedList(pageNumber, 1);
        //    return View();
        //}







    }
}
