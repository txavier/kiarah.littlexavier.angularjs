using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IStatisticService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.statistic>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.statistic> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.statistic AddOrUpdate(Kiarah.LittleXavier.Core.Models.statistic statistic);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.StatisticViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.StatisticViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.statistic> results);
        Kiarah.LittleXavier.Core.Models.StatisticViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.statistic statistic);
    }
}
