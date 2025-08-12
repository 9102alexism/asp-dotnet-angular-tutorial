using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class User {
    // [Key]
    public int Id { get; init; }
    [StringLength(100)]
    public required string Name { get; set; }
}