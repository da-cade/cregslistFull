using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cregslistFull.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string? Color { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? ImgUrl { get; set; }
    public int Price { get; set; }
    public string CreatorId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
  }
}