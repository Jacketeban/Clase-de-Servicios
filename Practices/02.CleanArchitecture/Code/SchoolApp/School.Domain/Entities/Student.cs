using School.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities;

[Table("Students")]
public class Student : EntityBase
{

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; } = default;

    [Required]
    [RegularExpression(@"[M|F]", ErrorMessage = "Invalid Sex Value")]
    public char Sex { get; set; } = 'M';
}
