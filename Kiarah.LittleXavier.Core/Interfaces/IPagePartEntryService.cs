using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IPagePartEntryService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.pagePartEntry>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.pagePartEntry> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.pagePartEntry AddOrUpdate(Kiarah.LittleXavier.Core.Models.pagePartEntry pagePartEntry);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.PagePartEntryViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.PagePartEntryViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.pagePartEntry> results);
        Kiarah.LittleXavier.Core.Models.PagePartEntryViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.pagePartEntry pagePartEntry);
    }
}
