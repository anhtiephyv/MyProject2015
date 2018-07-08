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
    [Authorize]
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
                  IEnumerable<AdminModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AdminModel>>(model);

                  PaginationSet<AdminModel> pagedSet = new PaginationSet<AdminModel>()
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
