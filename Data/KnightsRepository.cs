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
      return _db.QueryFirstOrDefault<Knight>(sql, new { id });
    }

    public int CreateKnight(Knight knightData)
    {
      var sql = @"
      INSERT INTO knight
      (name, homeCastle, questId, questsCompleted, gold)
      VALUES
      (@name, @homeCastle, @questId, @questsCompleted, @gold);
      SELECT LAST_INSERT_ID();
      ";

      return _db.ExecuteScalar<int>(sql, knightData);
    }

    public int UpdateKnight(Knight knightData)
    {
      var sql = @"
        Update knight 
        SET name = @name, 
        homeCastle = @homeCastle, 
        questId = @questId, 
        questsCompleted = @questsCompleted, 
        gold = @gold
        WHERE id = @id;
        ";
      return _db.Execute(sql, knightData);
    }

    public int DeleteKnight(int id)
    {
      var sql = @"
      DELETE FROM knight WHERE id = @id
      ";
      return _db.Execute(sql, new { id });
    }
  }
}