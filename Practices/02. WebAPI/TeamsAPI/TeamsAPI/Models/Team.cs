using System.ComponentModel.DataAnnotations;

namespace TeamsAPI.Models
{
    public class Team
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null;

        public string Coach { get; set; } = null;
  

        public virtual List<TeamMember> Members { get; set; } = new List<TeamMember>();
    }
}
