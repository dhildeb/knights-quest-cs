using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights_quest_cs.Models;

namespace knights_quest_cs.Data
{

  public class QuestsRepository
  {
    private readonly IDbConnection _db;
    public QuestsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Quest> GetAll()
    {
      var sql = "SELECT * FROM quest";
      return _db.Query<Quest>(sql).ToList();
    }

    public Quest GetById(int id)
    {
      var sql = "SELECT * FROM quest WHERE id = @id";
      return _db.ExecuteScalar<Quest>(sql);
    }

    public Quest CreateQuest(Quest questData)
    {
      var sql = @"
      INSERT INTO quest(title, description, reward, completed);
      VALUES(@title, @description, @reward, @completed);
      SELECT LAST_INSERT_ID();
      ";

      int id = _db.ExecuteScalar<int>(sql, questData);
      questData.Id = id;
      return questData;
    }

    public Quest CompleteQuest(int questId, int knightId)
    {
      var sql = @"
      UPDATE quest SET completed = true
      ";
      _db.ExecuteScalar<int>(sql, questId);
      var questSQL = "SELECT * FROM quest WHERE id = @questId";
      var quest = _db.ExecuteScalar<Quest>(questSQL, questId);
      int reward = quest.Reward;
      var knightSQL = "UPDATE knight WHERE id = @knightId SET gold = gold + @reward";
      var knight = _db.ExecuteScalar<Knight>(knightSQL, (knightId, reward));
      return quest;
    }
  }
}