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
    [RoutePrefix("api/pagePartEntries")]
    public class PagePartEntriesController : ApiController
    {
        private readonly IPagePartEntryService _pagePartEntryService;

        public PagePartEntriesController()
        {
            var container = IoC.Initialize();

            _pagePartEntryService = container.GetInstance<IPagePartEntryService>();
        }

        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _pagePartEntryService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _pagePartEntryService.Find(id);

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _pagePartEntryService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _pagePartEntryService.SearchCount(searchCriteria);

            return Ok(result);
        }

        // POST: api/cityApi
        public IHttpActionResult Post(pagePartEntry pagePartEntry)
        {
            _pagePartEntryService.AddOrUpdate(pagePartEntry);

            return Ok(pagePartEntry);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _pagePartEntryService.Delete(id);

            return Ok();
        }
    }
}
