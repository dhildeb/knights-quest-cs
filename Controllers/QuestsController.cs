using System.Collections.Generic;
using knights_quest_cs.Models;
using knights_quest_cs.Service;
using Microsoft.AspNetCore.Mvc;

namespace knights_quest_cs.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class QuestsController : ControllerBase
  {
    private readonly QuestsService _qs;
    public QuestsController(QuestsService questsService)
    {
      _qs = questsService;
    }

    [HttpGet]
    public ActionResult<List<Quest>> GetQuests()
    {
      try
      {
        var quests = _qs.GetAll();
        return Ok(quests);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Quest> GetQuestById(int id)
    {
      try
      {
        var quest = _qs.GetById(id);
        return Ok(quest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Quest> CreateQuest([FromBody] Quest questData)
    {
      try
      {
        var quest = _qs.CreateQuest(questData);
        return Created($"api/quests/{quest.Id}", quest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{knightId}")]
    public ActionResult<Quest> CompleteQuest(int knightId)
    {
      try
      {
        var quest = _qs.CompleteQuest(knightId);
        return Ok(quest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
