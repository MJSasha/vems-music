using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllUsers
    {
        Task<User> GetUserByIdAsync(int id);
        Task AddMusicToUserAsync(int musicId, int userId);
        Task RemoveMusicAsync(int musicId, int userId);
    }
}
