using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using cregslistFull.Repositories;

namespace cregslistFull.Services
{
  public class HousesService
  {
    internal readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
      _repo = repo;
    }

    internal List<House> GetAll()
    {
      return _repo.GetAll();
    }

    internal House Get(int id)
    {
      return _repo.Get(id);
    }

    internal House Create(House houseData)
    {
      return _repo.Create(houseData);
    }

    internal House Edit(int id, House update)
    {
      House original = Get(id);
      if (update.CreatorId != original.CreatorId)
      {
        throw new Exception("You are bad");
      }
      original.Description = update.Description ?? original.Description;
      original.ImgUrl = update.ImgUrl ?? original.ImgUrl;
      original.Bedrooms = update.Bedrooms;
      original.Bathrooms = update.Bathrooms;
      original.Price = update.Price;
      original.Year = update.Year;
      original.Levels = update.Levels;

      _repo.Edit(id, original);
      return original;
    }

    internal void Delete(int id, string userId)
    {
      House found = Get(id);
      if (found.CreatorId != userId)
      {
        throw new Exception("You are bad");
      }
      _repo.Delete(id);
    }
  }
}