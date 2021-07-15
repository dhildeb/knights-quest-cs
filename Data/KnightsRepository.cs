using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights_quest_cs.Models;

namespace knights_quest_cs.Data
{

  public class KnightsRepository
  {
    private readonly IDbConnection _db;
    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Knight> GetAll()
    {
      var sql = "SELECT * FROM knight";
      return _db.Query<Knight>(sql).ToList();
    }

    public Knight GetById(int id)
    {
      var sql = "SELECT * FROM knight WHERE id = @id";
      return _db.ExecuteScalar<Knight>(sql);
    }

    public Knight CreateKnight(Knight knightData)
    {
      var sql = @"
      INSERT INTO knight(name, homeCastle, quest, questsCompleted, gold);
      VALUES(@name, @homeCastle, @quest, @questsCompleted, @gold);
      SELECT LAST_INSERT_ID();
      ";

      int id = _db.ExecuteScalar<int>(sql, knightData);
      knightData.Id = id;
      return knightData;
    }

    public Knight UpdateKnight(Knight knightData, int id)
    {
      var sql = @"
  Update knight WHERE id = @id;
  SET name = @name, 
  homeCastle = @homeCastle, 
  quest = @quest, 
  questsCompleted = @questsCompleted, 
  gold = @gold;
  ";
      knightData.Id = id;
      return _db.ExecuteScalar<Knight>(sql, knightData);
    }
    public Knight DeleteKnight(int id)
    {
      var sql = @"
      DELETE knight WHERE id = @id
      ";
      return _db.ExecuteScalar<Knight>(sql);
    }
  }
}