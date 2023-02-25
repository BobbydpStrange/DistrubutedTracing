using api.Model;
using static api.Model.ActorModel;
using static api.Model.DiscoverModel;
using static api.Model.trendingModel;

namespace api.Service
{
    public class MovieService
    {
        private readonly HttpClient client;

        public MovieService(HttpClient client)
        {
            this.client = client;

        }

        public async Task<IEnumerable<Genre>> GetMovieGenreAsync()
        {
            var arrayOfGenre = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/genre/movie/list?api_key=989763942fa4f236cb34de985f499dc6&language=en-US");
            return arrayOfGenre.genres;
        }

        public async Task<IEnumerable<Genre>> GetTVShowsGenreAsync()
        {
            var arrayOfTvGenre = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/genre/tv/list?api_key=989763942fa4f236cb34de985f499dc6&language=en-US ");
            return arrayOfTvGenre.genres;
        }

        public async Task<string> GetMovieIdAsync()
        {
            var apiData = await client.GetFromJsonAsync<MovieInfo>("https://api.themoviedb.org/3/movie/550?api_key=989763942fa4f236cb34de985f499dc6");
            return apiData.title;
        }
        public async Task<IEnumerable<Result>> GetTrendingMovieAsync()
        {
            //var arrayOfTrendingMovies = new List<MovieInfo>();      
            var arrayOfTrendingMovies = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/trending/movie/week?api_key=989763942fa4f236cb34de985f499dc6");
            return arrayOfTrendingMovies.results;
        }

        public async Task<IEnumerable<Result>> GetTrendingTvAsync()
        {
            var arrayOfTrendingTv = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/trending/tv/week?api_key=989763942fa4f236cb34de985f499dc6");
            return arrayOfTrendingTv.results;
        }

        public async Task<IEnumerable<Actor>> GetPopularActorAsync()
        {
            var arrayOfPopularActors = await client.GetFromJsonAsync<Cast>("https://api.themoviedb.org/3/person/popular?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&page=1");
            return arrayOfPopularActors.results;
        }

        public async Task<IEnumerable<Output>> GetDiscoverAsync()
        {
            var arrayOfDiscover = await client.GetFromJsonAsync<Discover>("https://api.themoviedb.org/3/discover/movie?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_watch_monetization_types=flatrate");
            return arrayOfDiscover.results;
        }
        public async Task<IEnumerable<Result>> GetPlayingAsync()
        {
            var arrayOfPlaying = await client.GetFromJsonAsync<Collection>("https://api.themoviedb.org/3/movie/now_playing?api_key=989763942fa4f236cb34de985f499dc6&language=en-US&page=1");
            return arrayOfPlaying.results;
        }
    }
}
