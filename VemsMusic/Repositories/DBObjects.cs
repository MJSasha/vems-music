using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Models;

namespace VemsMusic.Repositories
{
    public class DBObjects
    {
        public static async Task InitialAsync(AppDBContext context)
        {
            if (!context.Genres.Any())
            {
                await context.AddRangeAsync(
                    new Genre
                    {
                        Name = "Рок",
                        Description = "Анархия",
                        PicturePath = ""
                    });
            }
            if (!context.Groups.Any())
            {
                await context.AddRangeAsync(
                    new MusicalGroup
                    {
                        Name = "Анархисты",
                        Description = "Анархируют",
                        Picture = "",
                        GenreName = "Рок"
                    });
            }
            await context.SaveChangesAsync();
        }

    }
}
