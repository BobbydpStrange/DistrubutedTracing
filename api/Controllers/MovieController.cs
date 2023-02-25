using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static api.Model.ActorModel;
using static api.Model.DiscoverModel;
using static api.Model.trendingModel;

namespace api.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient client;

        public MovieController(HttpClient client)
        {
            this.client = client;

        }
        [HttpGet("/Genre")]
        public async Task<IEnumerable<Genre>> GetMovieGenreAsync()
        {
            var arrayOfGenre = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/genre/movie/list?api_key=989763942fa4f236cb34de985f499dc6&language=en-US");
            return arrayOfGenre.genres;
        }

        [HttpGet("/TvShows")]
        public async Task<IEnumerable<Genre>> GetTVShowsGenreAsync()
        {
            var arrayOfTvGenre = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/genre/tv/list?api_key=989763942fa4f236cb34de985f499dc6&language=en-US ");
            return arrayOfTvGenre.genres;
        }

        [HttpGet("/MovieId")]
        public async Task<string> GetMovieIdAsync()
        {
            var apiData = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/movie/550?api_key=989763942fa4f236cb34de985f499dc6");
            return apiData.title;
        }

        [HttpGet("/Trending")]
        public async Task<IEnumerable<Result>> GetTrendingMovieAsync()
        {
            //var arrayOfTrendingMovies = new List<MovieInfo>();      
            var arrayOfTrendingMovies = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/trending/movie/week?api_key=989763942fa4f236cb34de985f499dc6");
            Array.Sort(arrayOfTrendingMovies.results);
            return arrayOfTrendingMovies.results;
        }

        [HttpGet("/TrendingTv")]
        public async Task<IEnumerable<Result>> GetTrendingTvAsync()
        {
            var arrayOfTrendingTv = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/trending/tv/week?api_key=989763942fa4f236cb34de985f499dc6");
            return arrayOfTrendingTv.results;
        }

        [HttpGet("/PopularActor")]
        public async Task<IEnumerable<Actor>> GetPopularActorAsync()
        {
            var arrayOfPopularActors = await client.GetFromJsonAsync<Cast>("https://api.themoviedb.org/3/person/popular?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&page=1");
            return arrayOfPopularActors.results;
        }

        [HttpGet("/Discover")]
        public async Task<IEnumerable<Output>> GetDiscoverAsync()
        {
            var arrayOfDiscover = await client.GetFromJsonAsync<Discover>("https://api.themoviedb.org/3/discover/movie?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_watch_monetization_types=flatrate");
            return arrayOfDiscover.results;
        }

        [HttpGet("/Playing")]
        public async Task<IEnumerable<Result>> GetPlayingAsync()
        {
            var arrayOfPlaying = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/movie/now_playing?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&page=1");
            return arrayOfPlaying.results;
        }
    }
}
