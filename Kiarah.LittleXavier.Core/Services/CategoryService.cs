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
    public class CategoryService : Service<category>, ICategoryService
    {
        public CategoryService(IRepository<category> categoryRepository)
            : base(categoryRepository)
        {

        }

        public IEnumerable<category> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? true 
                   : i.name.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.name),
               orderBy: j => searchCriteria.orderBy == "messageTitle" ? j.OrderBy(k => k.name) : j.OrderBy(k => k.name),
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
                                      : i.name.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.name));

            return result;
        }

        public category AddOrUpdate(category category)
        {
            category.blogEntries = null;

            category = base.AddOrUpdate(category);

            return category;
        }

        public IEnumerable<CategoryViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<CategoryViewModel> ToViewModels(IEnumerable<category> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public CategoryViewModel ToViewModel(category category)
        {
            var categoryViewModel = new CategoryViewModel();

            categoryViewModel.InjectFrom(category);

            return categoryViewModel;
        }
    }
}
