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
      return _db.QueryFirstOrDefault<Quest>(sql, new { id });
    }

    public int CreateQuest(Quest questData)
    {
      var sql = @"
      INSERT INTO quest
      (title, description, reward, completed)
      VALUES
      (@title, @description, @reward, @completed);
      SELECT LAST_INSERT_ID();";

      return _db.ExecuteScalar<int>(sql, questData);
    }

    public int CompleteQuest(Knight knight)
    {
      var sql = @"
      UPDATE quest 
      SET completed = true
      WHERE id = @questId;";
      return _db.ExecuteScalar<int>(sql, knight);
    }
  }
}