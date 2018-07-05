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
       // private ICountryRepository _CountryRepository;
        public CountryController(ICountryService CountryService)
        {
            _Country = CountryService;
         //   _CountryRepository = CountryRepository;
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
                var list = model.Select(s => new { ID = s.CountryID, Name = s.CountryName }).ToList();
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
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CountryModel countryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var modelVm = Mapper.Map<CountryModel, Country>(countryVm);
                
                    _Country.Create(modelVm);
                    _Country.Save();

                    var responseData = Mapper.Map<Country, CountryModel>(modelVm);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
