using System.ComponentModel.DataAnnotations;

namespace FL_Test_2.Repository.Entities;

public class Tag
{
    [Key]
    public Guid TagId { get; set; }

    [Required]
    public string Value { get; set; } = default!;
    [Required]
    public string Domain { get; set; } = default!;

    public List<TagToUser>? TagToUsers { get; set; }

    public override string ToString()
    {
        return string.Format($"TagId: {TagId} Value: {Value} Domain: {Domain}");
    }
}
