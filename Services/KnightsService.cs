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
      return _knightsRepo.CreateKnight(knightData);
    }

    public Knight UpdateKnight(Knight knightData, int id)
    {
      return _knightsRepo.UpdateKnight(knightData, id);
    }
    public object DeleteKnight(int id)
    {
      return _knightsRepo.DeleteKnight(id);
    }
  }
}