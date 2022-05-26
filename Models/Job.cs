using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cregslistFull.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Company { get; set; }
    public string? StartsAt { get; set; }
    public string? Location { get; set; }
    public string CreatorId { get; set; }
  }
}