using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllUsers
    {
        User GetUserById(int id);
        void AddMusicToUser(int musicId, int userId);
    }
}
