using System;
namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IMyJourneyService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.myJourney>
    {
        Kiarah.LittleXavier.Core.Models.myJourney AddOrUpdate(Kiarah.LittleXavier.Core.Models.myJourney myJourney, string loggedInUsername);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyJourneyViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myJourney> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.MyJourneyViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.myJourney myJourney);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.MyJourneyViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.myJourney> results);
    }
}
