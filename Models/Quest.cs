using System.ComponentModel.DataAnnotations;

namespace knights_quest_cs.Models
{
  public class Quest
  {
    public Quest(int id, string title, string description, int reward)
    {
      Id = id;
      Title = title;
      Description = description;
      Reward = reward;
      Completed = false;
    }

    public int Id { get; set; }
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Range(1, 9999999)]
    public int Reward { get; set; }
    public bool Completed { get; set; }
  }
}