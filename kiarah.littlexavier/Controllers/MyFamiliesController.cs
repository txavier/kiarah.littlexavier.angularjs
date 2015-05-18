using Kiarah.LittleXavier.Core.Interfaces;
using Kiarah.LittleXavier.Core.Models;
using Kiarah.LittleXavier.Core.Objects;
using Kiarah.LittleXavier.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kiarah.LittleXavier.Controllers
{
    [RoutePrefix("api/MyFamilies")]
    public class MyFamiliesController : ApiController
    {
        private readonly IMyFamilyService _myFamilyService;

        public MyFamiliesController()
        {
            var container = IoC.Initialize();

            _myFamilyService = container.GetInstance<IMyFamilyService>();
        }

        [Route("")]
        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _myFamilyService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _myFamilyService.Find(id);

            return Ok(result);
        }

        [Route("{year}/{month}/{myFamilyName}")]
        [HttpGet]
        public IHttpActionResult Get(int year, int month, string myFamilyName)
        {
            var myFamily = _myFamilyService.Get(filter: i =>
                i.date.Year == year
                && i.date.Month == month
                && i.messageTitle == myFamilyName
                ).
                FirstOrDefault();

            return Ok(myFamily);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _myFamilyService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _myFamilyService.SearchCount(searchCriteria);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        // POST: api/cityApi
        public IHttpActionResult Post(myFamily myFamily)
        {
            _myFamilyService.AddOrUpdate(myFamily, User.Identity.Name);

            return Ok(myFamily);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _myFamilyService.Delete(id);

            return Ok();
        }
    }
}
