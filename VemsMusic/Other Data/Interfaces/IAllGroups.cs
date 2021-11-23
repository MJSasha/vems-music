using System.Collections.Generic;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    public interface IAllGroups
    {
        IEnumerable<MusicalGroup> GetMusicalGroups { get; }
        MusicalGroup GetMusicalGroupById(int id);
        void DeleteGroup(int id);
        void AddGroup(MusicalGroup musicalGroup);
        void UpdateGroup(MusicalGroup musicalGroup);
    }
}
