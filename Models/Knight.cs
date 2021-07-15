using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace knights_quest_cs.Models
{
  public class Knight
  {
    public Knight(string name, string homeCastle, List<Quest> quest, int questCompleted, int gold, int id)
    {
      Name = name;
      HomeCastle = homeCastle;
      Quest = quest;
      QuestCompleted = questCompleted;
      Gold = gold;
      Id = id;
    }

    [Required]
    public string Name { get; set; }
    public string HomeCastle { get; set; }
    public List<Quest> Quest { get; set; }
    public int QuestCompleted { get; set; }
    public int Gold { get; set; }
    public int Id { get; set; }
  }
}