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
    [RoutePrefix("api/MyJournies")]
    public class MyJourniesController : ApiController
    {
        private readonly IMyJourneyService _myJourneyService;

        public MyJourniesController()
        {
            var container = IoC.Initialize();

            _myJourneyService = container.GetInstance<IMyJourneyService>();
        }

        [Route("")]
        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _myJourneyService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _myJourneyService.Find(id);

            return Ok(result);
        }

        [Route("{year}/{month}/{myJourneyName}")]
        [HttpGet]
        public IHttpActionResult Get(int year, int month, string myJourneyName)
        {
            var myJourney = _myJourneyService.Get(filter: i =>
                i.date.Year == year
                && i.date.Month == month
                && i.messageTitle == myJourneyName
                ).
                FirstOrDefault();

            return Ok(myJourney);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _myJourneyService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _myJourneyService.SearchCount(searchCriteria);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        // POST: api/cityApi
        public IHttpActionResult Post(myJourney myJourney)
        {
            _myJourneyService.AddOrUpdate(myJourney, User.Identity.Name);

            return Ok(myJourney);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _myJourneyService.Delete(id);

            return Ok();
        }
    }
}
