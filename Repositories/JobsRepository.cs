using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using cregslistFull.Models;
using Dapper;

namespace cregslistFull.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql).ToList();
    }
    internal Job Get(int id)
    {
      string sql = "SELECT * FROM jobs job WHERE job.id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
    internal Job Create(Job jobData)
    {
      string sql = @"
      INSERT INTO jobs
      (title, company, description, startsAt, location, creatorId)
      VALUES
      (@Title, @Company, @Description, @StartsAt, @Location, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      jobData.Id = _db.ExecuteScalar<int>(sql, jobData);
      return jobData;
    }
    internal Job Edit(int id, Job original)
    {
      string sql = @"
      UPDATE jobs
      SET
        title = @Title,
        company = @Company,
        description = @Description,
        startsAt = @StartsAt,
        location = @Location,
        creatorId = @CreatorId
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}