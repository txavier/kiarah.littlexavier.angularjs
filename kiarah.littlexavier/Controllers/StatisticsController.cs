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
    [RoutePrefix("api/statistics")]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController()
        {
            var container = IoC.Initialize();

            _statisticService = container.GetInstance<IStatisticService>();
        }

        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _statisticService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _statisticService.Find(id);

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _statisticService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _statisticService.SearchCount(searchCriteria);

            return Ok(result);
        }

        // POST: api/cityApi
        public IHttpActionResult Post(statistic statistic)
        {
            _statisticService.AddOrUpdate(statistic);

            return Ok(statistic);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _statisticService.Delete(id);

            return Ok();
        }
    }
}
