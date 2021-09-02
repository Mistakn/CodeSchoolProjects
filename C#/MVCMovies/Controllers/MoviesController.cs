using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMovies.Data;
using MVCMovies.Models;

namespace MVCMovies.Controllers {
    public class MoviesController : Controller {
        private readonly MVCMoviesContext _context;

        public MoviesController(MVCMoviesContext context) {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string searchQuery, string genreQuery, string ratingQuery) {

            var movies = _context.Movie.AsQueryable();
            var movieGenres = movies.Select(m => m.Genre).Distinct();
            var movieRatings = movies.Select(m => m.Rating).Distinct();
            var recentMovies = movies.OrderBy(m => m.ReleaseDate).Take(5);

            if (searchQuery != null) {
                movies = movies.Where(m => m.Title.Contains(searchQuery));
            }

            if (genreQuery != null) {
                movies = movies.Where(m => m.Genre == genreQuery);
            }

            if (ratingQuery != null) {
                movies = movies.Where(m => m.Rating == ratingQuery);
            }

            MovieGenreViewModel viewModel = new MovieGenreViewModel {
                Movies = await movies.ToListAsync(),
                RecentMovies = await recentMovies.ToListAsync(),
                SearchQuery = searchQuery,
                GenreQuery = genreQuery,
                RatingQuery = ratingQuery,
                Genres = new SelectList(await movieGenres.ToListAsync()),
                Ratings = new SelectList(await movieRatings.ToListAsync())
            };

            return View(viewModel);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null) {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie) {
            if (ModelState.IsValid) {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null) {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Title,ReleaseDate,Genre,Price")] Movie movie) {
            if (id != movie.MovieID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!MovieExists(movie.MovieID)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null) {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RecentMovies() {
            return PartialView("_RecentMovies");
        }


        private bool MovieExists(int id) {
            return _context.Movie.Any(e => e.MovieID == id);
        }
    }
}
