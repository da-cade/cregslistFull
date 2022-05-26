using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using Dapper;

namespace cregslistFull.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Car> GetAll()
    {
      string sql = @"
        SELECT * FROM cars
        ";
      return _db.Query<Car>(sql).ToList();
    }

    internal Car Get(int id)
    {
      string sql = @"
        SELECT * FROM cars car
        WHERE car.id = @id
      ";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });
    }

    internal Car Create(Car carData)
    {
      string sql = @"
      INSERT INTO cars
      (color, make, model, imgUrl, price, year, creatorId)
      VALUES
      (@Color, @Make, @Model, @ImgUrl, @Price, @Year, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      carData.Id = _db.ExecuteScalar<int>(sql, carData);
      return carData;
    }

    internal Car Edit(int id, Car original)
    {
      string sql = @"
      UPDATE cars
      SET
       color = @Color,
       make = @Make,
       model = @Model,
       imgUrl = @ImgUrl,
       year = @Year,
       price = @Price,
       creatorId =@CreatorId
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;

    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM cars WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });

    }
  }
}