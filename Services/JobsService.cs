using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using cregslistFull.Repositories;

namespace cregslistFull.Services
{
  public class JobsService
  {
    internal readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal List<Job> GetAll()
    {
      return _repo.GetAll();
    }

    internal Job Get(int id)
    {
      return _repo.Get(id);
    }

    internal Job Create(Job jobData)
    {
      return _repo.Create(jobData);
    }

    internal Job Edit(int id, Job update)
    {
      Job original = Get(id);
      if (update.CreatorId != original.CreatorId)
      {
        throw new Exception("You are bad");
      }

      original.Title = update.Title ?? original.Title;
      original.Description = update.Description ?? original.Description;
      original.StartsAt = update.StartsAt ?? original.StartsAt;
      original.Location = update.Location ?? original.Location;
      original.Company = update.Company ?? original.Company;

      _repo.Edit(id, original);
      return original;
    }

    internal void Delete(int id, string userId)
    {
      Job found = Get(id);
      if (found.CreatorId != userId)
      {
        throw new Exception("You are bad");
      }
      _repo.Delete(id);
    }
  }
}