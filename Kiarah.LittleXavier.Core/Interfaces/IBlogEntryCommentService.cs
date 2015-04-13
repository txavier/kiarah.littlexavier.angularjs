using System;

namespace Kiarah.LittleXavier.Core.Interfaces
{
    public interface IBlogEntryCommentService : AutoClutch.Auto.Service.Interfaces.IService<Kiarah.LittleXavier.Core.Models.blogEntryComment>
    {
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.blogEntryComment> Search(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        int SearchCount(Kiarah.LittleXavier.Core.Objects.SearchCriteria searchCriteria);
        Kiarah.LittleXavier.Core.Models.blogEntryComment AddOrUpdate(Kiarah.LittleXavier.Core.Models.blogEntryComment blogEntryComment, string loggedInUsername);
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.BlogEntryCommentViewModel> GetAllViewModels();
        System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.BlogEntryCommentViewModel> ToViewModels(System.Collections.Generic.IEnumerable<Kiarah.LittleXavier.Core.Models.blogEntryComment> results);
        Kiarah.LittleXavier.Core.Models.BlogEntryCommentViewModel ToViewModel(Kiarah.LittleXavier.Core.Models.blogEntryComment blogEntryComment);
    }
}
