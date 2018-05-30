using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Sherk!" };
            List<Customer> customers = new List<Customer>
            {
                new Customer{Name="Customer 1"},
                new Customer{Name="Customer 2"},
                new Customer{Name="Customer 3"},
                new Customer{Name="Customer 4"}
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);

        }

        public ActionResult Edit(int id)
        {

            return Content("id=" + id);
        }

        //Movies
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{


        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;


        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}

        //Movies
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();


            return View(movies);

        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);


        }

        private IEnumerable<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie{Id=1,Name="Sherk"},
                new Movie{Id=2,Name="Wall-e"}
            };

            return movies;

        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }

}