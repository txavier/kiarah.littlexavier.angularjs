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
    public class MyFamilyService : Service<myFamily>, IMyFamilyService
    {
        public MyFamilyService(IRepository<myFamily> myFamilyRepository)
            : base(myFamilyRepository)
        {

        }

        public IEnumerable<myFamily> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? 
                   ((searchCriteria.myFamilyTitle != null ? i.messageTitle == searchCriteria.myFamilyTitle : true)
                   && (searchCriteria.year.HasValue && searchCriteria.month.HasValue ? 
                        i.date.Year == searchCriteria.year && i.date.Month == searchCriteria.month : true)
                   && (searchCriteria.year != null ? i.date.Year == searchCriteria.year : true)
                   && (searchCriteria.month != null ? i.date.Month == searchCriteria.month : true))
                   : i.messageBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.messageBody)
                   || i.messageTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.messageTitle),
               orderBy: j => searchCriteria.orderBy == "messageTitle" ? j.OrderBy(k => k.messageTitle) : j.OrderBy(k => k.date),
               skip: ((searchCriteria.currentPage - 1) ?? 1) * (searchCriteria.itemsPerPage ?? int.MaxValue),
               take: (searchCriteria.itemsPerPage ?? int.MaxValue),
               includeProperties: searchCriteria.includeProperties);

            return result;
        }

        public int SearchCount(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
                GetCount()
                : GetCount(
                filter: i => searchCriteria.searchText == null ? true
                   : i.messageBody.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.messageBody)
                   || i.messageTitle.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.messageTitle));

            return result;
        }

        public myFamily AddOrUpdate(myFamily myFamily, string loggedInUsername)
        {
            // If this is an update then dont update the related entities
            // too.
            if (myFamily.myFamilyId != 0)
            {
                // If the blog entry is not new and the user name of the person making the update to 
                // this blog entry is not the same as the original blog entryer then do not continue
                // with the update.
                if (myFamily.userName != loggedInUsername)
                {
                    return myFamily;
                }
            }
            else
            {
                // If we are saving for the first time then...
                myFamily.userName = loggedInUsername;

                myFamily.date = DateTime.Now;
            }

            myFamily = base.AddOrUpdate(myFamily);


            return myFamily;
        }

        public IEnumerable<MyFamilyViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<MyFamilyViewModel> ToViewModels(IEnumerable<myFamily> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public MyFamilyViewModel ToViewModel(myFamily myFamily)
        {
            var myFamilyViewModel = new MyFamilyViewModel();

            myFamilyViewModel.InjectFrom(myFamily);

            return myFamilyViewModel;
        }
    }
}
