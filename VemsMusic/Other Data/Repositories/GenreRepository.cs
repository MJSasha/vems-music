using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Interfaces;
using VemsMusic.Models;

namespace VemsMusic.Repositories
{
    public class GenreRepository : IAllGenre
    {
        private readonly AppDBContext _dbContext;

        public GenreRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<Genre> GetAllGenres
        {
            get
            {
                return _dbContext.Genres.ToList();
            }
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _dbContext.FindAsync<Genre>(id);
        }

        public async Task DeleteGenreAsync(int id)
        {
            _dbContext.Genres.Remove(_dbContext.Genres.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddGenreAsync(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _dbContext.Genres.Update(genre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
