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

        private IEnumerable<Genre> GetAllGenres
        {
            get
            {
                return _dbContext.Genres.ToList();
            }
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await Task.Run(() => GetAllGenres);
        }
        public async Task<Genre> GetGenreByIdAsync(int genreId)
        {
            return await _dbContext.FindAsync<Genre>(genreId);
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
        public async Task DeleteGenreAsync(int genreId)
        {
            _dbContext.Genres.Remove(_dbContext.Genres.Find(genreId));
            await _dbContext.SaveChangesAsync();
        }

    }
}
