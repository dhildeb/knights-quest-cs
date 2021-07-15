using System;
using System.Collections.Generic;
using knights_quest_cs.Data;
using knights_quest_cs.Models;

namespace knights_quest_cs.Service
{
  public class QuestsService
  {
    private readonly QuestsRepository _questsRepo;
    public QuestsService(QuestsRepository questsRepo)
    {
      _questsRepo = questsRepo;
    }

    public List<Quest> GetAll()
    {
      return _questsRepo.GetAll();
    }

    public Quest GetById(int id)
    {
      return _questsRepo.GetById(id);
    }

    public Quest CreateQuest(Quest questData)
    {
      return _questsRepo.CreateQuest(questData);
    }

    public object CompleteQuest(int questId, int knightId)
    {
      return _questsRepo.CompleteQuest(questId, knightId);
    }
  }
}