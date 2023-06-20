using System.ComponentModel.DataAnnotations;


namespace SchoolAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]              
        public String FirstName { get; set; } = null!;

        [Required]
        public String LastName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; } = default;

        [Required]
        public char Sex { get; set; } = 'M';
        





    }
}
