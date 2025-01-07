using System.ComponentModel.DataAnnotations;

namespace CRM.Common.Dtos;

public class UserDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string FamilyName { get; set; }

    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
}
