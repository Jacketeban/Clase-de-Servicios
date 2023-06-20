using System.ComponentModel.DataAnnotations;

namespace School.Domain.Common;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}