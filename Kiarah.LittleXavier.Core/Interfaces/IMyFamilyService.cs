using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IMyFamilyService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.myFamily>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myFamily> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.myFamily AddOrUpdate(Kiarah.LittleXavier.Core.Models.myFamily myFamily, string loggedInUserName);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyFamilyViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyFamilyViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myFamily> results);
        Kiarah.LittleXavier.Core.Models.MyFamilyViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.myFamily myFamily);
    }
}
