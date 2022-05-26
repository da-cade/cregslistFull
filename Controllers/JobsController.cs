using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using cregslistFull.Models;
using cregslistFull.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }


    [HttpGet]
    public ActionResult<List<Job>> GetAll()
    {
      try
      {
        List<Job> jobs = _js.GetAll();
        return Ok(jobs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        Job job = _js.Get(id);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Job>> Create([FromBody] Job jobData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        jobData.CreatorId = userInfo.Id;
        Job newJob = _js.Create(jobData);
        return Ok(newJob);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Job>> Edit(int id, [FromBody] Job jobUpdate)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        jobUpdate.CreatorId = userInfo.Id;
        jobUpdate.Id = id;
        Job job = _js.Edit(id, jobUpdate);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _js.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}