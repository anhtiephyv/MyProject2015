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
using Data.Repository;
using AutoMapper.QueryableExtensions;
namespace MyProject.Api
{
    [RoutePrefix("api/Country")]
    [AllowAnonymous]
    public class CountryController : BaseController
    {
        //private IAppUsersService _usersService;
        private ICountryService _Country;
        private ICountryRepository _CountryRepository;
        public CountryController(ICountryService CountryService, ICountryRepository CountryRepository)
        {
            _Country = CountryService;
            _CountryRepository = CountryRepository;
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
          //      Func<Country, Object> orderByFunc = null;
                HttpResponseMessage response = null;
                 //t int totalRow;
                int totalRow = 0;
         //       var Orderprop = helpler.GetPropertyValue(typeof(Country), orderby);
                var model = _Country.GetMultiPaging(x => x.CountryName != null, out totalRow, orderby, sortDir, page, pageSize, null );
                IEnumerable<CountryModel> modelVm = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryModel>>(model);

                PaginationSet<CountryModel> pagedSet = new PaginationSet<CountryModel>()
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
