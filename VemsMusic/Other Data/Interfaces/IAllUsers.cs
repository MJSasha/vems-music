using System.Threading.Tasks;
using VemsMusic.Models;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Other_Data.Interfaces
{
    /// <summary>
    /// Encapsulates all methods related to editing user information.
    /// </summary>
    public interface IAllUsers
    {
        /// <summary>
        /// Writes a new user to the database.
        /// </summary>
        /// <param name="user">Added user.</param>
        Task AddNewUser(User user);
        /// <summary>
        /// Returns a user matching the registration model from the database.
        /// </summary>
        /// <param name="registerModel">The registration model of the searched for user.</param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="Other_Data.PersonalExceptions.NotFound"></exception>
        Task<User> GetUserByRegistraterModelAsync(RegisterViewModel registerModel);
        /// <summary>
        /// Returns a user matching the login model from the database.
        /// </summary>
        /// <param name="loginModel">The login model of the searched for user.</param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="Other_Data.PersonalExceptions.NotFound"></exception>
        Task<User> GetUserByLoginModelAsync(LoginViewModel loginModel);
        /// <summary>
        /// Returns the user with the specified id from the database.
        /// </summary>
        /// <param name="userId">User id that will be retrieved from the database.</param>
        /// <returns><see cref="User"/></returns>
        Task<User> GetUserByIdAsync(int userId);
        /// <summary>
        /// Creates a connection between the music and the user. 
        /// If the user already has such music, then the music is updated in the database.
        /// </summary>
        /// <param name="musicId">The id of the music to be added to the user.</param>
        /// <param name="userId">The id of the user to which the music will be added.</param>
        /// <exception cref="MusicAlreadyAdded">Music has already been added to the user.</exception>
        Task AddMusicToUserAsync(int musicId, int userId);
        /// <summary>
        /// Removes the link between the user and the music.
        /// </summary>
        /// <param name="musicId">The id of the music to be removed.</param>
        /// <param name="userId">User with the given music.</param>
        Task RemoveMusicFromUserAsync(int musicId, int userId);
    }
}
