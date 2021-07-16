using System.ComponentModel.DataAnnotations;

namespace knights_quest_cs.Models
{
  public class Quest
  {

    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    public string Description { get; set; }

    [Range(1, 9999999)]
    public int Reward { get; set; }
    public bool Completed { get; set; }
  }
}