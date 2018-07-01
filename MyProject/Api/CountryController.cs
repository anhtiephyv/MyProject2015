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
    [RoutePrefix("api/Country")]
    [AllowAnonymous]
    public class CountryController : BaseController
    {
        //private IAppUsersService _usersService;
        private ICountryService _Country;

        public CountryController(CountryService CountryService)
        {
            _Country = CountryService;
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

                var model = _Country.GetPaging( page, pageSize, null, orderby, sortDir,filter);
                IEnumerable<CountryModel> modelVm = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryModel>>(model);

                PaginationSet<CountryModel> pagedSet = new PaginationSet<CountryModel>()
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
