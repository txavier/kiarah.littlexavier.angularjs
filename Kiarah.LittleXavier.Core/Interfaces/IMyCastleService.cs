using System;
namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IMyCastleService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.myCastle>
    {
        Kiarah.LittleXavier.Core.Models.myCastle AddOrUpdate(Kiarah.LittleXavier.Core.Models.myCastle myCastle, string loggedInUsername);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyCastleViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myCastle> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.MyCastleViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.myCastle myCastle);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyCastleViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myCastle> results);
    }
}
