using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using Dapper;

namespace cregslistFull.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<House> GetAll()
    {
      string sql = "SELECT * FROM houses";
      return _db.Query<House>(sql).ToList();
    }

    internal House Get(int id)
    {
      string sql = "SELECT * FROM houses house WHERE house.id = @id";
      return _db.QueryFirstOrDefault<House>(sql, new { id });
    }
    internal House Create(House houseData)
    {
      string sql = @"
      INSERT INTO houses
      (bedrooms, bathrooms, levels, year, price, imgUrl, description, creatorId)
      VALUES
      (@Bedrooms, @Bathrooms, @Levels, @Year, @Price, @ImgUrl, @Description, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      houseData.Id = _db.ExecuteScalar<int>(sql, houseData);
      return houseData;
    }

    internal House Edit(int id, House original)
    {
      string sql = @"
      UPDATE houses
      SET
        bedrooms = @Bedrooms,
        bathrooms = @Bathrooms,
        levels = @Levels,
        year = @Year,
        price = @Price,
        imgUrl = @ImgUrl,
        description = @Description, 
        creatorId = @CreatorId
       WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;

    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM houses WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}