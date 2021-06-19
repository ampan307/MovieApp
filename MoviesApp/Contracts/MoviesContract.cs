using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MoviesApp.Models;
using System.Text.Json;

namespace MoviesApp.Contracts
{
	public class MoviesContract
	{

		
		public Movies GetList()
		{
			try
			{

				string fileName = "movies.json";
				string jsonString = File.ReadAllText(fileName);
				var moviesList = JsonSerializer.Deserialize<Movies>(jsonString);
				return moviesList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<MoviesModel> GetMovieList()
		{
			return GetList().movies.OrderByDescending(x=> float.Parse(x.imdbRating)).ToList();
		}

		public List<MoviesModel> GetMoviesByLocation(string location)
		{
			return GetList().movies.FindAll(x => x.Location.Equals(location, StringComparison.InvariantCultureIgnoreCase)).OrderByDescending(x => float.Parse(x.imdbRating)).ToList();
		}

		public List<MoviesModel> GetMoviesByLanguage(string language)
		{
			return GetList().movies.FindAll(x => x.Language.Equals(language, StringComparison.InvariantCultureIgnoreCase)).OrderByDescending(x => float.Parse(x.imdbRating)).ToList();
		}

		public List<MoviesModel> GetMoviesByListingType(string listingType)
		{
			return GetList().movies.FindAll(x => x.listingType.Equals(listingType, StringComparison.InvariantCultureIgnoreCase)).OrderByDescending(x => float.Parse(x.imdbRating)).ToList();
		}

		public MoviesModel GetMovieDetailsById(string imdbId)
		{
			return GetList().movies.FirstOrDefault(x => x.imdbID.Equals(imdbId, StringComparison.InvariantCultureIgnoreCase));
		}

		public List<MoviesModel> SearchMovieById(string searchString)
		{
			return GetList().movies.FindAll(x => x.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
		}

		public List<MoviesModel> SortMoviesByTitle(string order)
		{
			if (order.Equals("Descending"))
			{
				return GetList().movies.OrderByDescending(x => x.Title).ToList();

			}
			else
			{
				return GetList().movies.OrderBy(x => x.Title).ToList();
			}
		}


	}
}
