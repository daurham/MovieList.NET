namespace MovieList2.Controllers;

using Microsoft.AspNetCore.Mvc;

using MovieList2.Models;

public class MovieController : Controller
{
  private readonly MyDbContext _dbCtx;
  public MovieController(MyDbContext dbCtx)
  {
    _dbCtx = dbCtx;
  }

  // route for pulling up 1 movie
  public IActionResult Index(int id)
  {
    var movie = _dbCtx.Movies.Find(id); 
    ViewData["Title"] = $"{movie.Title}";
    return View(movie);
  }

  public IActionResult AddMovie()
  {
    return View();
  }

  [HttpPost]
  public IActionResult AddMovie(Movie movie)
  {
    
    // if (!ModelState.IsValid)
    // {
    //   ViewData["add-msg"] = "Improper fields filled";
    //   return View();
    // }
    
    // I dont want to check this ^^^ here bc I want to manually handle unfilled fields here  
    if (string.IsNullOrEmpty(movie.ImageURL)) movie.ImageURL = "https://thumbs.dreamstime.com/b/no-image-available-icon-photo-camera-flat-vector-illustration-132483141.jpg";
    try
    {
      _dbCtx.Movies.Add(movie);
      _dbCtx.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    catch (System.Exception)
    {
      ViewData["add-msg"] = "Error adding";
      return View();
    }
  }
  public IActionResult EditMovie(Movie movie)
  {
    try
    {
      if (!ModelState.IsValid) {
        // IF some of the data isnt passed in, Use the ID to find the rest of the obj
        System.Console.WriteLine("Not getting all the data:");
        System.Console.WriteLine(movie.Id);
        System.Console.WriteLine(movie.ImageURL);
        System.Console.WriteLine(movie.Title);
        System.Console.WriteLine(movie.HasWatched);
        var _movie = _dbCtx.Movies.Find(movie.Id);
        return View(_movie);
      } 
      // Else the rest has been passed in!
      _dbCtx.Movies.Update(movie);
      _dbCtx.SaveChanges();
      return RedirectToAction("Index", "Home");

    }
    catch (System.Exception)
    {
      ViewData["delete-msg"] = "Error removing";
      return View();
    }
  }
  public IActionResult DeleteMovie(int id)
  {
    try
    {
      var movie = _dbCtx.Movies.Find(id);
      _dbCtx.Movies.Remove(movie);
      _dbCtx.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    catch (System.Exception)
    {
      ViewData["delete-msg"] = "Error removing";
      return RedirectToAction("Index", "Home");
    }
  }
}