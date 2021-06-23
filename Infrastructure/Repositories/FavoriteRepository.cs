using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Favorite>> GetAllFavoritesByMovieId(int movieId)
        {
            var favorites = await _dbContext.Favorites.Where(f => f.MovieId == movieId).Include(m => m.Movie)
                .Include(m => m.User)
                .ToListAsync();

            return favorites;
        }
    }
}