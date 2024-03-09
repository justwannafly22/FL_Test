using System.ComponentModel.DataAnnotations;

namespace FL_Test_2.Repository.Entities;

public class TagToUser
{
    [Key]
    public Guid EntityId { get; set; }

    [Required]
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    [Required]
    public Guid TagId { get; set; }
    public virtual Tag? Tag { get; set; }
}
