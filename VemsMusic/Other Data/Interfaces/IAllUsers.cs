using VemsMusic.Models;

namespace VemsMusic.Other_Data.Interfaces
{
    public interface IAllUsers
    {
        User GetUserByEmail(string email);
    }
}
