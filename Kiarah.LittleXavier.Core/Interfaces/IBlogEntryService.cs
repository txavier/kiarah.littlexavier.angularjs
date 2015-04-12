using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IBlogEntryService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.blogEntry>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.blogEntry> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.blogEntry AddOrUpdate(Kiarah.LittleXavier.Core.Models.blogEntry blogEntry, string loggedInUserName);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.BlogEntryViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.BlogEntryViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.blogEntry> results);
        Kiarah.LittleXavier.Core.Models.BlogEntryViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.blogEntry blogEntry);
    }
}
