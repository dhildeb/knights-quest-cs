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
    public ActionResult<Quest> GetQuests(int id)
    {
      try
      {
        var quests = _qs.GetById(id);
        return Ok(quests);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Quest> CreateQuest(Quest questData)
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

    [HttpDelete]
    public ActionResult<Quest> CompleteQuest(int questId, int knightId)
    {
      try
      {
        var quest = _qs.CompleteQuest(questId, knightId);
        return Ok(quest);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
