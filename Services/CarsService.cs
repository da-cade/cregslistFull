using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using cregslistFull.Repositories;

namespace cregslistFull.Services
{
  public class CarsService
  {
    internal readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal List<Car> GetAll()
    {
      return _repo.GetAll();
    }

    internal Car Get(int id)
    {
      return _repo.Get(id);
    }

    internal Car Create(Car carData)
    {
      return _repo.Create(carData);
    }

    internal Car Edit(int id, Car carData)
    {

      Car original = Get(id);
      if (carData.CreatorId != original.CreatorId)
      {
        throw new Exception("You are bad.");
      }
      // TODO creatorID
      original.Color = carData.Color ?? original.Color;
      original.Make = carData.Make ?? original.Make;
      original.Model = carData.Model ?? original.Model;
      original.ImgUrl = carData.ImgUrl ?? original.ImgUrl;
      original.Year = carData.Year;
      original.Price = carData.Price;

      return _repo.Edit(id, original);
    }

    internal void Delete(int id, string userId)
    {
      Car car = Get(id);
      if (car.CreatorId != userId)
      {
        throw new Exception("You are bad.");
      }
      _repo.Delete(id);
    }
  }
}