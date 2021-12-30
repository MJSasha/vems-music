using System.Collections.Generic;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Interfaces
{
    /// <summary>
    /// Encapsulates all methods related to editing music group information.
    /// </summary>
    public interface IAllGroups
    {
        /// <summary>
        /// Returns all music groups recorded in the database.
        /// </summary>
        /// <returns><see cref="IEnumerable{MusicalGroup}">IEnumerable&lt;MusicalGroup&gt;</see></returns>
        Task<IEnumerable<MusicalGroup>> GetAllMusicalGroupsAsync();
        /// <summary>
        /// Returns the music group with the given id from the database.
        /// </summary>
        /// <param name="groupId">The id of the group that will be retrieved from the database.</param>
        /// <returns><see cref="MusicalGroup"/></returns>
        Task<MusicalGroup> GetMusicalGroupByIdAsync(int groupId);
        /// <summary>
        /// Adds a group to the database.
        /// </summary>
        /// <param name="musicalGroup">The group to add.</param>
        Task AddGroupAsync(MusicalGroup musicalGroup);
        /// <summary>
        /// Updates the given music group in the database.
        /// </summary>
        /// <param name="musicalGroup">A new kind of <see cref="MusicalGroup"/>.</param>
        Task UpdateGroupAsync(MusicalGroup musicalGroup);
        /// <summary>
        /// Removes the specified genre from the specified group.
        /// </summary>
        /// <param name="GroupId">The ID of the group from which the genre will be deleted.</param>
        /// <param name="GenreId">The id of the genre to be deleted.</param>
        Task DeleteGroupsGenreAsync(int GroupId, int GenreId);
        /// <summary>
        /// Delete group in the database.
        /// </summary>
        /// <param name="groupId">The id of the group to be deleted.</param>
        Task DeleteGroupAsync(int groupId);
    }
}
