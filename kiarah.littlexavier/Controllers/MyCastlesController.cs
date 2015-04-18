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
    [RoutePrefix("api/MyCastles")]
    public class MyCastlesController : ApiController
    {
        private readonly IMyCastleService _myCastleService;

        public MyCastlesController()
        {
            var container = IoC.Initialize();

            _myCastleService = container.GetInstance<IMyCastleService>();
        }

        [Route("")]
        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _myCastleService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _myCastleService.Find(id);

            return Ok(result);
        }

        [Route("{year}/{month}/{myCastleName}")]
        [HttpGet]
        public IHttpActionResult Get(int year, int month, string myCastleName)
        {
            var myCastle = _myCastleService.Get(filter: i =>
                i.date.Year == year
                && i.date.Month == month
                && i.messageTitle == myCastleName
                ).
                FirstOrDefault();

            return Ok(myCastle);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _myCastleService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _myCastleService.SearchCount(searchCriteria);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        // POST: api/cityApi
        public IHttpActionResult Post(myCastle myCastle)
        {
            _myCastleService.AddOrUpdate(myCastle, User.Identity.Name);

            return Ok(myCastle);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _myCastleService.Delete(id);

            return Ok();
        }
    }
}
