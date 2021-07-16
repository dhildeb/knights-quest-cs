using System;
using System.Collections.Generic;
using knights_quest_cs.Data;
using knights_quest_cs.Models;

namespace knights_quest_cs.Service
{
  public class QuestsService
  {
    private readonly QuestsRepository _questsRepo;
    private readonly KnightsRepository _knightsRepo;
    private readonly KnightsService _ks;
    public QuestsService(QuestsRepository questsRepo, KnightsRepository knightsRepo, KnightsService ks)
    {
      _questsRepo = questsRepo;
      _knightsRepo = knightsRepo;
      _ks = ks;
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
      int id = _questsRepo.CreateQuest(questData);
      questData.Id = id;
      return questData;
    }

    public int CompleteQuest(int knightId)
    {
      var knight = _ks.GetById(knightId);
      var quest = GetById(knight.QuestId);
      knight.Gold += quest.Reward;
      knight.QuestsCompleted++;
      knight.QuestId = 0;
      knight.Id = knightId;
      _knightsRepo.UpdateKnight(knight);
      return _questsRepo.CompleteQuest(knight);
    }
  }
}