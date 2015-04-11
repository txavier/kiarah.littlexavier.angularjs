using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IPageEntryService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.pageEntry>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.pageEntry> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.pageEntry AddOrUpdate(Kiarah.LittleXavier.Core.Models.pageEntry pageEntry);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.PageEntryViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.PageEntryViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.pageEntry> results);
        Kiarah.LittleXavier.Core.Models.PageEntryViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.pageEntry pageEntry);
    }
}
