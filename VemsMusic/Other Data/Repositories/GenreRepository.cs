using System.Collections.Generic;
using System.Linq;
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

        public Genre GetGenreById(int id)
        {
            return _dbContext.Find<Genre>(id);
        }

        public async void DeleteGenre(Genre genre)
        {
            _dbContext.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async void UpdateGenre(Genre genre)
        {
            _dbContext.Genres.Update(genre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
