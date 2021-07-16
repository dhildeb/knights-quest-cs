using System;
using System.Collections.Generic;
using knights_quest_cs.Data;
using knights_quest_cs.Models;

namespace knights_quest_cs.Service
{
  public class KnightsService
  {
    private readonly KnightsRepository _knightsRepo;
    public KnightsService(KnightsRepository knightsRepo)
    {
      _knightsRepo = knightsRepo;
    }

    public List<Knight> GetAll()
    {
      return _knightsRepo.GetAll();
    }

    public Knight GetById(int id)
    {
      return _knightsRepo.GetById(id);
    }

    public Knight CreateKnight(Knight knightData)
    {
      knightData.QuestsCompleted = 0;
      int id = _knightsRepo.CreateKnight(knightData);
      knightData.Id = id;
      return knightData;
    }

    public Knight UpdateKnight(Knight knightData, int id)
    {
      knightData.Id = id;
      var original = GetById(id);
      knightData.Gold = knightData.Gold != 0 ? knightData.Gold : original.Gold;
      knightData.Name = knightData.Name != null ? knightData.Name : original.Name;
      knightData.QuestId = knightData.QuestId != 0 ? knightData.QuestId : original.QuestId;
      knightData.QuestsCompleted = knightData.QuestsCompleted != 0 ? knightData.QuestsCompleted : original.QuestsCompleted;

      int updated = _knightsRepo.UpdateKnight(knightData);
      if (updated > 0)
      {
        return knightData;
      }
      else
      {
        throw new Exception("couldnt update");
      }

    }
    public object DeleteKnight(int id)
    {
      return _knightsRepo.DeleteKnight(id);
    }
  }
}