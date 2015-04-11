using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IBlogEntryService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.blogEntry>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.blogEntry> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
    }
}
