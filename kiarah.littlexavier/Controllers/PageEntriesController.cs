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
    [RoutePrefix("api/pageEntries")]
    public class PageEntriesController : ApiController
    {
        private readonly IPageEntryService _pageEntryService;

        public PageEntriesController()
        {
            var container = IoC.Initialize();

            _pageEntryService = container.GetInstance<IPageEntryService>();
        }

        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _pageEntryService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _pageEntryService.Find(id);

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _pageEntryService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _pageEntryService.SearchCount(searchCriteria);

            return Ok(result);
        }

        // POST: api/cityApi
        public IHttpActionResult Post(pageEntry pageEntry)
        {
            _pageEntryService.AddOrUpdate(pageEntry);

            return Ok(pageEntry);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _pageEntryService.Delete(id);

            return Ok();
        }
    }
}
