using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
	public class Movies
	{
		public List<MoviesModel> movies { get; set; }
	}
	public class MoviesModel
	{
		public string imdbID { get; set; }
		public string Title { get; set; }
		//public MovieDetailsModel Details;

		public string Location { get; set; }
		public string Language { get; set; }
		public string Plot { get; set; }
		public string imdbRating { get; set; }
		public string listingType { get; set; }
		public string Poster { get; set; }
		public List<string> Stills { get; set; }
		public List<string> SoundEffects { get; set; }

	}
}
