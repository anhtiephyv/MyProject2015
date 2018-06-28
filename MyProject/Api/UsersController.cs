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
namespace MyProject.Api
{
    [RoutePrefix("api/users")]
    //[Authorize]
    public class UsersController : BaseController
    {
        private IApplicationUsersService _usersService;


        public UsersController(IApplicationUsersService usersService)
        {
            _usersService = usersService;
        }
        [Route("getlistpaging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string orderby, string sortDir, string filter = null)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;

                var model = _usersService.GetPaging(out totalRow, page, pageSize, null, orderby, sortDir, null);
                IEnumerable<UserModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserModel>>(model);

                PaginationSet<UserModel> pagedSet = new PaginationSet<UserModel>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
