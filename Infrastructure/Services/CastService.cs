using ApplicationCore.Exceptions;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository; 
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetById(id);
            if (cast == null)
            {
                throw new NotFoundException( "not found");
            }
            var mlist = new List<MovieResponseModel>();
            foreach (var mc in cast.MovieCasts)
            {
                mlist.Add(new MovieResponseModel
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    PosterUrl = mc.Movie.PosterUrl,
                    ReleaseDate = mc.Movie.ReleaseDate
                }); ;
            }
            var response = new CastDetailsResponseModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = mlist
            };
    
            return response;
        }

        
    }
}
