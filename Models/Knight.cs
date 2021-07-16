using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace knights_quest_cs.Models
{
  public class Knight
  {

    [Required]
    public string Name { get; set; }
    public string HomeCastle { get; set; }
    public int QuestId { get; set; }
    public int QuestsCompleted { get; set; }
    public int Gold { get; set; }
    public int Id { get; set; }
  }
}