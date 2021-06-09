using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task <List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task <MovieDetailsResponseModel> GetMovieDetailsById(int id);
        Task <MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequest);
    }
}
