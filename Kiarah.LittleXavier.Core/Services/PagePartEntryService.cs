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
    public class PagePartEntryService : Service<pagePartEntry>, IPagePartEntryService
    {
        public PagePartEntryService(IRepository<pagePartEntry> pagePartEntryRepository)
            : base(pagePartEntryRepository)
        {

        }

        public IEnumerable<pagePartEntry> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? true
                   : i.pagePartTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pagePartTitle)
                   || i.pagePartBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pagePartBody),
               orderBy: j => searchCriteria.orderBy == "pageTitle" ? j.OrderBy(k => k.pagePartTitle) : j.OrderBy(k => k.dateCreated),
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
                   : i.pagePartTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pagePartTitle)
                   || i.pagePartBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.pagePartBody));

            return result;
        }

        public pagePartEntry AddOrUpdate(pagePartEntry pagePartEntry)
        {
            if(pagePartEntry.pageEntryId == 0 && pagePartEntry.pageEntry != null)
            {
                pagePartEntry.pageEntryId = pagePartEntry.pageEntry.pageEntryId;
            }
            
            pagePartEntry.pageEntry = null;

            pagePartEntry = base.AddOrUpdate(pagePartEntry);

            return pagePartEntry;
        }

        public IEnumerable<PagePartEntryViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<PagePartEntryViewModel> ToViewModels(IEnumerable<pagePartEntry> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public PagePartEntryViewModel ToViewModel(pagePartEntry pagePartEntry)
        {
            var pagePartEntryViewModel = new PagePartEntryViewModel();

            pagePartEntryViewModel.InjectFrom(pagePartEntry);

            return pagePartEntryViewModel;
        }
    }
}
