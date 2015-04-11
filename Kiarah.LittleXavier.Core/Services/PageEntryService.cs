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
    public class PageEntryService : Service<pageEntry>, IPageEntryService
    {
        public PageEntryService(IRepository<pageEntry> pageEntryRepository)
            : base(pageEntryRepository)
        {

        }

        public IEnumerable<pageEntry> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? true
                   : i.pageTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pageTitle)
                   || i.pageBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pageBody),
               orderBy: j => searchCriteria.orderBy == "pageTitle" ? j.OrderBy(k => k.pageTitle) : j.OrderBy(k => k.dateCreated),
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
                   : i.pageTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pageTitle)
                   || i.pageBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pageBody));

            return result;
        }

        public pageEntry AddOrUpdate(pageEntry pageEntry)
        {
            pageEntry.pagePartEntries = null;

            pageEntry = base.AddOrUpdate(pageEntry);

            return pageEntry;
        }

        public IEnumerable<PageEntryViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<PageEntryViewModel> ToViewModels(IEnumerable<pageEntry> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public PageEntryViewModel ToViewModel(pageEntry pageEntry)
        {
            var pageEntryViewModel = new PageEntryViewModel();

            pageEntryViewModel.InjectFrom(pageEntry);

            return pageEntryViewModel;
        }
    }
}
