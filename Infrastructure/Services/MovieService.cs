using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using System.Collections.Generic;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IGenreRepository _genreRepository;
        public MovieService(IMovieRepository movieRepository, ICurrentUserService currentUserService, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _currentUserService = currentUserService;
        }
        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighestRevenueMovies();

            var movieCardList = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCardList.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    Title = movie.Title
                });
            }

            return movieCardList;
        }
        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovies();

            var movieCardList = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCardList.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    Title = movie.Title
                });
            }

            return movieCardList;
        }
        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            var glist = new List<GenreResponseModel>();
            var clist = new List<CastResponseModel>();
            foreach (var genre in movie.Genres)
            {
                glist.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            foreach (var mc in movie.MovieCasts)
            {
                clist.Add(new CastResponseModel
                {
                    Id = mc.CastId,
                    Name = mc.Cast.Name,
                    Gender = mc.Cast.Gender,
                    TmdbUrl = mc.Cast.TmdbUrl,
                    ProfilePath = mc.Cast.ProfilePath,
                    Character = mc.Character
                }); ;
            }
            var movieDetailResponseModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                RunTime = movie.RunTime,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Genres = glist,
                Casts = clist,
            };

            return movieDetailResponseModel;
        }
        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel mCR)
        {
            if (_currentUserService.IsAdmin==false) {
                throw new Exception("You are not Authorized to purchase");
            }
            // // check whether the user is Admin and can create the movie claim

            var movie = new Movie
            {
                BackdropUrl = mCR.BackdropUrl,
                Budget = mCR.Budget,
                Genres = mCR.Genres,
                ImdbUrl = mCR.ImdbUrl,
                OriginalLanguage = mCR.OriginalLanguage,
                Overview = mCR.Overview,
                PosterUrl = mCR.PosterUrl,
                Price = mCR.Price,
                ReleaseDate = mCR.ReleaseDate,
                Revenue = mCR.Revenue,
                RunTime = mCR.RunTime,
                Tagline = mCR.Tagline,
                Title = mCR.Title,
                TmdbUrl = mCR.TmdbUrl
            };

            var createdMovie = await _movieRepository.Add(movie);
            var grm = new List<GenreResponseModel>();
            if (mCR.Genres != null)
            {
                foreach (var genre in mCR.Genres)
                {
                    grm.Add(new GenreResponseModel { Id = genre.Id, Name = genre.Name }
                        );
                }
            }
            var MDR = new MovieDetailsResponseModel
            {
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                Genres = grm,
                ImdbUrl = movie.ImdbUrl,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                RunTime = movie.RunTime,
                Tagline = movie.Tagline,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl

            };
            return MDR;
        }
        public async Task<List<MovieReviewResponseModel>> GetReviewsByMovieId(int id)
        {
            var reviews = await _movieRepository.GetMovieReviews(id);

            var response = new List<MovieReviewResponseModel>();

            foreach (var review in reviews)
            {
                response.Add(new MovieReviewResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                });
            }

            return response;
        }

    }
        
}
