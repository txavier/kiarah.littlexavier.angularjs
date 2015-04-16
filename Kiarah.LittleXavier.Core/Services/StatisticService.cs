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
    public class StatisticService : Service<statistic>, IStatisticService
    {
        public StatisticService(IRepository<statistic> statisticRepository)
            : base(statisticRepository)
        {

        }

        public IEnumerable<statistic> Search(SearchCriteria searchCriteria)
        {
            var result = searchCriteria == null ?
               Get()
               : Get(
               filter: i => searchCriteria.searchText == null ? 
                   (string.IsNullOrEmpty(searchCriteria.key) ? true : i.statisticKey == searchCriteria.key)
                   : i.statisticKey.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.statisticKey)
                   || i.statisticValue.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.statisticValue),
               orderBy: j => searchCriteria.orderBy == "messageTitle" ? j.OrderBy(k => k.statisticKey) : j.OrderBy(k => k.statisticKey),
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
                                      : i.statisticKey.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.statisticKey)
                                        || i.statisticValue.Contains(searchCriteria.searchText) || searchCriteria.searchText.Contains(i.statisticValue));

            return result;
        }

        public statistic AddOrUpdate(statistic statistic)
        {
            statistic = base.AddOrUpdate(statistic);

            return statistic;
        }

        public IEnumerable<StatisticViewModel> GetAllViewModels()
        {
            var results = Get(lazyLoadingEnabled: false, proxyCreationEnabled: false);

            var resultViewModels = ToViewModels(results);

            return resultViewModels;
        }

        public IEnumerable<StatisticViewModel> ToViewModels(IEnumerable<statistic> results)
        {
            var result = results.Select(i => ToViewModel(i));

            return result;
        }

        public StatisticViewModel ToViewModel(statistic statistic)
        {
            var statisticViewModel = new StatisticViewModel();

            statisticViewModel.InjectFrom(statistic);

            return statisticViewModel;
        }
    }
}
