using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MoviesApp.Contracts;

namespace MoviesApp.Controllers
{
	[Route("api")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private MoviesContract _moviesContract;

		public MoviesController()
		{
			_moviesContract = new MoviesContract();
		}

		//Get All Movies
		[HttpGet]
		[Route("get/movies")]
		public IActionResult GetMovies()
		{
			
			var list = _moviesContract.GetMovieList();
			return Ok(list);
		}

		//Get Movies by Location
		[HttpGet]
		[Route("get/movies/location/{location}")]
		public IActionResult GetMoviesByCity(string location)
		{
			var list = _moviesContract.GetMoviesByLocation(location);
			return Ok(list);
		}

		//Get Movies by Language
		[HttpGet]
		[Route("get/movies/language/{language}")]
		public IActionResult GetMoviesByLanguage( string language)
		{
			var list = _moviesContract.GetMoviesByLanguage(language);
			return Ok(list);
		}

		//Get Movies by Listing Type
		[HttpGet]
		[Route("get/movies/listingtype/{listingType}")]
		public IActionResult GetMoviesByReleaseType(string listingType)
		{
			var list = _moviesContract.GetMoviesByListingType(listingType);
			return Ok(list);
		}

		//Get Movie Details by IMDB Id
		[HttpGet]
		[Route("get/movies/detail/{imdbId}")]
		public IActionResult GetMovieDetailsById(string imdbId)
		{
			var movieDetails = _moviesContract.GetMovieDetailsById(imdbId);
			return Ok(movieDetails);
		}

		//Search Movie by search string
		[HttpGet]
		[Route("get/movies/search/{searchString}")]
		public IActionResult SearchMovieByTitle(string searchString)
		{
			var movieDetails = _moviesContract.SearchMovieById(searchString);
			return Ok(movieDetails);
		}


		//Sort Movies by Title
		[HttpGet]
		[Route("get/movies/sort/{order}")]
		public IActionResult SortMoviesByTitle(string order)
		{
			var movieDetails = _moviesContract.SortMoviesByTitle(order);
			return Ok(movieDetails);
		}

	}
}
