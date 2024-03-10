using System.ComponentModel.DataAnnotations;

namespace FL_Test_2.Repository.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Domain { get; set; }

    public virtual List<TagToUser>? TagToUsers { get; set; }

    public override string ToString()
    {
        return string.Format($"UserId: {UserId} Name: {Name} Domain: {Domain}");
    }
}
