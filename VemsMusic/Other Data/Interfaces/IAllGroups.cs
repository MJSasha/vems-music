using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    public interface IAllGroups
    {
        IEnumerable<MusicalGroup> GetMusicalGroups { get; }
        Task<IEnumerable<MusicalGroup>> GetMusicalGroupsAsync();
        Task<MusicalGroup> GetMusicalGroupByIdAsync(int id);
        Task DeleteGroupAync(int id);
        Task AddGroupAsync(MusicalGroup musicalGroup);
        Task UpdateGroupAsync(MusicalGroup musicalGroup);
    }
}
