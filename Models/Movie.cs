using System.ComponentModel.DataAnnotations;

namespace MovieList2.Models;

public class Movie
{
  public int Id { get; set; }
  [Required]
  public string Title { get; set; } = "";
  public string ImageURL { get; set; } = "";
  public bool HasWatched { get; set; } = false;
}