﻿/*
 * ITSE 1430
 * Lab 4
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatrickFief.MovieLib.Data
{
    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {        
        /// <summary>Add a new movie.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="Exception">A movie with the same name already exists.</exception>
        /// <remarks>
        /// Returns an error if movie is null, invalid or if a movie
        /// with the same name already exists.
        /// </remarks>
        public Movie Add ( Movie movie )
        {            
            //if (movie == null) throw new ArgumentNullException(nameof(movie));
            movie = movie ?? throw new ArgumentNullException(nameof(movie));
            movie.Validate();

            // Verify unique movie
            var existing = GetMovieByNameCore(movie.Title);
            if (existing != null)
                throw new Exception("Movie already exists");
            
            return AddCore(movie);
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>The list of movies.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            return from p in GetAllCore()
                   orderby p.Title, p.Id descending
                   select p;                                   
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="id">The movie ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        public void Remove ( int id )
        {
            //Return an error if id <= 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");

            RemoveCore(id);
        }

        /// <summary>Edits an existing movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="Exception">A movie with the same name already exists.</exception>
        /// <exception cref="ArgumentException">The movie does not exist.</exception>
        /// <remarks>
        /// Returns an error if movie is null, invalid, movie name
        /// already exists or if the movie cannot be found.
        /// </remarks>
        public Movie Update ( Movie movie )
        {
            //Check for null
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            //Validate movie 
            movie.Validate();

            // Verify unique movie
            var existing = GetMovieByNameCore(movie.Title);
            if (existing != null && existing.Id != movie.Id)
                throw new Exception("Movie already exists");

            //Find existing
            existing = existing ?? GetCore(movie.Id);
            if (existing == null)
                throw new ArgumentException("Movie not found", nameof(movie));

            return UpdateCore(movie);
        }
                
        protected abstract Movie AddCore( Movie movie );
        protected abstract IEnumerable<Movie> GetAllCore();
        protected abstract Movie GetCore( int id );
        protected abstract void RemoveCore( int id );
        protected abstract Movie UpdateCore( Movie movie );
        protected abstract Movie GetMovieByNameCore( string name );
    }
}
