using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface ICategoryService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.category>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.category> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.category AddOrUpdate(Kiarah.LittleXavier.Core.Models.category category);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.CategoryViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.CategoryViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.category> results);
        Kiarah.LittleXavier.Core.Models.CategoryViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.category category);
    }
}
