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
  public class HousesController : ControllerBase
  {
    private readonly HousesService _hs;
    public HousesController(HousesService hs)
    {
      _hs = hs;
    }

    [HttpGet]
    public ActionResult<List<House>> GetAll()
    {
      try
      {
        List<House> houses = _hs.GetAll();
        return Ok(houses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<House> Get(int id)
    {
      try
      {
        House house = _hs.Get(id);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<House>> Create([FromBody] House houseData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        houseData.CreatorId = userInfo.Id;
        House newHouse = _hs.Create(houseData);
        return Ok(newHouse);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<House>> Edit(int id, [FromBody] House houseData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        houseData.CreatorId = userInfo.Id;
        houseData.Id = id;
        House house = _hs.Edit(id, houseData);
        return Ok(house);
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
        _hs.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}