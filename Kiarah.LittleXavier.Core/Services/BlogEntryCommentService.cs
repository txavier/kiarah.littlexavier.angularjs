using AutoClutch.Auto.Repo.Interfaces;
using AutoClutch.Auto.Service.Services;
using Kiarah.LittleXavier.Core.Interfaces;
using Kiarah.LittleXavier.Core.Models;
using Kiarah.LittleXavier.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace Kiarah.LittleXavier.Core.Services
{
    public class BlogEntryCommentService : Service<blogEntryComment>, IBlogEntryCommentService
    {
        public BlogEntryCommentService(IRepository<blogEntryComment> blogEntryCommentRepository)
            : base(blogEntryCommentRepository)
        {

        }

        public IEnumerable<blogEntryComment> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? true
                   : i.comment.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.comment),
               orderBy: j => searchCriteria.orderBy == "dateCreated" ? j.OrderBy(k => k.dateCreated) : j.OrderBy(k => k.dateCreated),
               skip: ((searchCriteria.currentPage - 1) ?? 1) * (searchCriteria.itemsPerPage ?? int.MaxValue),
               take: (searchCriteria.itemsPerPage ?? int.MaxValue));

            return result;
        }

        public int SearchCount(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
                GetCount()
                : GetCount(
                filter: i => searchCriteria.searchText == null ? true
                            : i.comment.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.comment));

            return result;
        }

        public blogEntryComment AddOrUpdate(blogEntryComment blogEntryComment)
        {
            blogEntryComment = base.AddOrUpdate(blogEntryComment);

            return blogEntryComment;
        }

        public IEnumerable<BlogEntryCommentViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<BlogEntryCommentViewModel> ToViewModels(IEnumerable<blogEntryComment> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public BlogEntryCommentViewModel ToViewModel(blogEntryComment blogEntryComment)
        {
            var blogEntryCommentViewModel = new BlogEntryCommentViewModel();

            blogEntryCommentViewModel.InjectFrom(blogEntryComment);

            return blogEntryCommentViewModel;
        }
    }
}
