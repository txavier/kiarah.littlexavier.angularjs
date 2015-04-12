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
    [RoutePrefix("api/BlogEntries")]
    public class BlogEntriesController : ApiController
    {
        private readonly IBlogEntryService _blogEntryService;

        public BlogEntriesController()
        {
            var container = IoC.Initialize();

            _blogEntryService = container.GetInstance<IBlogEntryService>();
        }

        [Route("")]
        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _blogEntryService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _blogEntryService.Find(id);

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _blogEntryService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _blogEntryService.SearchCount(searchCriteria);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        // POST: api/cityApi
        public IHttpActionResult Post(blogEntry blogEntry)
        {
            _blogEntryService.AddOrUpdate(blogEntry, User.Identity.Name);

            return Ok(blogEntry);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _blogEntryService.Delete(id);

            return Ok();
        }
    }
}
