using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyProject.Base;
using Service.Service;
using AutoMapper;
using Data.Models;
using MyProject.helper;
using MyProject.Model;
using MyProject.Mapping;
using AutoMapper.QueryableExtensions;
namespace MyProject.Api
{
    [RoutePrefix("api/ApplicationUser")]
    [AllowAnonymous]
    public class ApplicationUserController : BaseController
    {
        //private IAppUsersService _usersService;
        private ApplicationUserManager _userManager;

        public ApplicationUserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        //public ApplicationUserController()
        //{
           
        //}
        [Route("getlistpaging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string orderby, string sortDir, string filter = null)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;

                var model = _userManager.Users;
                  IEnumerable<UserModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserModel>>(model);

                  PaginationSet<UserModel> pagedSet = new PaginationSet<UserModel>()
                {
                    Page = page,
                    TotalCount = model.Count(),
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
