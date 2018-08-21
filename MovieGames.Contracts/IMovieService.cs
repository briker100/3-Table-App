using ElevenNote.Models;
using MovieGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGames.Contracts
{
     public interface IMovieService
    {
        bool CreateMovie(MovieCreate model);
        IEnumerable<MovieListItem> GetMovies();
        MovieDetails GetMovieById(int movieId);
        bool UpdateNote(MovieEdit model);
        bool DeleteMovie(int MovieId);

    }
}
