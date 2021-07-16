using System.Collections.Generic;
using knights_quest_cs.Models;
using knights_quest_cs.Service;
using Microsoft.AspNetCore.Mvc;

namespace knights_quest_cs.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class KnightsController : ControllerBase
  {
    private readonly KnightsService _ks;
    public KnightsController(KnightsService knightsService)
    {
      _ks = knightsService;
    }

    [HttpGet]
    public ActionResult<List<Knight>> GetKnights()
    {
      try
      {
        var knights = _ks.GetAll();
        return Ok(knights);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Knight> GetKnightById(int id)
    {
      try
      {
        var knight = _ks.GetById(id);
        return Ok(knight);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Knight> CreateKnight([FromBody] Knight knightData)
    {
      try
      {
        var knight = _ks.CreateKnight(knightData);
        return Created($"api/knights/{knight.Id}", knight);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Knight> UpdateKnight([FromBody] Knight knightData, int id)
    {
      try
      {
        var knight = _ks.UpdateKnight(knightData, id);
        return Ok(knight);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete]
    public ActionResult<Knight> DeleteKnight(int id)
    {
      try
      {
        var knight = _ks.DeleteKnight(id);
        return Ok(knight);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
