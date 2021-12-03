using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    public interface IAllGroups
    {
        Task<IEnumerable<MusicalGroup>> GetMusicalGroupsAsync();
        Task DeleteGroupAsync(int id);
        Task DeleteGroupsGenreAsync(int GroupId, int GenreId);
        Task<MusicalGroup> GetMusicalGroupByIdAsync(int id);
        Task AddGroupAsync(MusicalGroup musicalGroup);
        Task UpdateGroupAsync(MusicalGroup musicalGroup);
    }
}
