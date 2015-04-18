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
    public class MyCastleService : Service<myCastle>, Kiarah.LittleXavier.Core.Interfaces.IMyCastleService
    {
        public MyCastleService(IRepository<myCastle> myCastleRepository)
            : base(myCastleRepository)
        {

        }

        public IEnumerable<myCastle> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? 
                   ((searchCriteria.myCastleTitle != null ? i.messageTitle == searchCriteria.myCastleTitle : true)
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

        public myCastle AddOrUpdate(myCastle myCastle, string loggedInUsername)
        {
            // If this is an update then dont update the related entities
            // too.
            if (myCastle.myCastleId != 0)
            {
                // If the blog entry is not new and the user name of the person making the update to 
                // this blog entry is not the same as the original blog entryer then do not continue
                // with the update.
                if (myCastle.userName != loggedInUsername)
                {
                    return myCastle;
                }
            }
            else
            {
                // If we are saving for the first time then...
                myCastle.userName = loggedInUsername;

                myCastle.date = DateTime.Now;
            }

            myCastle = base.AddOrUpdate(myCastle);


            return myCastle;
        }

        public IEnumerable<MyCastleViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<MyCastleViewModel> ToViewModels(IEnumerable<myCastle> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public MyCastleViewModel ToViewModel(myCastle myCastle)
        {
            var myCastleViewModel = new MyCastleViewModel();

            myCastleViewModel.InjectFrom(myCastle);

            return myCastleViewModel;
        }
    }
}
