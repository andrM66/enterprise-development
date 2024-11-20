using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRent.Domain.Entities;
/// <summary>
/// Bike avalible for rent
/// </summary>
[Table("bike")]
public class Bike
{
    /// <summary>
    /// Bike's id
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// Bike's type's id
    /// </summary>
    [Column("type_id")]
    [Required]
    public required int TypeId { get; set; }
    /// <summary>
    /// Bike's model
    /// </summary>
    [Column("model")]
    [MaxLength(10)]
    [Required]
    public required string Model { get; set; }
    /// <summary>
    /// Bike's color
    /// </summary>
    [Column("color")]
    [MaxLength(10)]
    [Required]
    public required string Color { get; set; }
}
