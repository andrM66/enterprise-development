using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRent.Domain.Entities;
/// <summary>
/// Class that represents specific bike types
/// </summary>
[Table("bike_type")]
public class BikeType
{
    /// <summary>
    /// Type's id
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// Rental cost
    /// </summary>
    [Column("price")]
    [MaxLength(10)]
    [Required]
    public required double Price { get; set; }
    /// <summary>
    /// Type's name
    /// </summary>
    [Column("name")]
    [MaxLength(10)]
    [Required]
    public required string Name { get; set; }
}