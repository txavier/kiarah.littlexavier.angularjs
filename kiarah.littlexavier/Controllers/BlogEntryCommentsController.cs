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
    [RoutePrefix("api/blogEntryComments")]
    public class BlogEntryCommentsController : ApiController
    {
        private readonly IBlogEntryCommentService _blogEntryCommentService;

        public BlogEntryCommentsController()
        {
            var container = IoC.Initialize();

            _blogEntryCommentService = container.GetInstance<IBlogEntryCommentService>();
        }

        // GET: api/cityApi
        public IHttpActionResult Get()
        {
            var result = _blogEntryCommentService.GetAll();

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _blogEntryCommentService.Find(id);

            return Ok(result);
        }

        [Route("search")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            var result = _blogEntryCommentService.Search(searchCriteria);

            return Ok(result);
        }

        [Route("search/count")]
        [HttpPost]
        // GET: api/cityApi/5
        public IHttpActionResult SearchCount(SearchCriteria searchCriteria)
        {
            var result = _blogEntryCommentService.SearchCount(searchCriteria);

            return Ok(result);
        }

        // POST: api/cityApi
        public IHttpActionResult Post(blogEntryComment blogEntryComment)
        {
            _blogEntryCommentService.AddOrUpdate(blogEntryComment, User.Identity.Name);

            return Ok(blogEntryComment);
        }

        // DELETE: api/cityApi/5
        public IHttpActionResult Delete(int id)
        {
            _blogEntryCommentService.Delete(id);

            return Ok();
        }
    }
}
