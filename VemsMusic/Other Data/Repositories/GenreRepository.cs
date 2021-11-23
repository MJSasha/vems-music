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

        public void DeleteGenre(int id)
        {
            _dbContext.Genres.Remove(_dbContext.Genres.Find(id));
            _dbContext.SaveChanges();
        }

        public void AddGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }
    }
}
