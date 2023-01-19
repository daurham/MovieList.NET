namespace MovieList2.Controllers;
using Microsoft.AspNetCore.Mvc; // Enables IAction result!
using MovieList2.Models;


public class HomeController : Controller // Dont forget to inherit from Controller !
{
  // get db contenxt
  private readonly MyDbContext _dbCtx;

  public HomeController(MyDbContext dbCtx)
  {
    _dbCtx = dbCtx;
  }

  // route to movielist

  public IActionResult Index()
  {
    try
    {
      ViewData["Title"] = "Movie List";
      // get all list items
       var movies = _dbCtx.Movies.ToList(); // Need to import movie!
      // return to view
      return View(movies);
    }
    catch (System.Exception)
    {
      return View();
    }
  }



}