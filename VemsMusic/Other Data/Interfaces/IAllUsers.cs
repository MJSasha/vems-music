using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllUsers
    {
        Task<User> GetUserById(int id);
        Task AddMusicToUser(int musicId, int userId);
        Task RemoveMusic(int musicId, int userId);
    }
}
