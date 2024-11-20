using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRent.Domain.Entities;
/// <summary>
/// Class that represents specific rental operation
/// </summary>
[Table("rent")]
public class Rent
{
    /// <summary>
    /// Client's id
    /// </summary>
    [Column("client_id")]
    [Required]
    public required int ClientId { get; set; }
    /// <summary>
    /// Bike's id
    /// </summary>
    [Column("bike_id")]
    [Required]
    public required int BikeId { get; set; }
    /// <summary>
    /// Start of the rent
    /// </summary>
    [Column("begin")]
    [Required]
    public required DateTime Begin { get; set; }
    /// <summary>
    /// End of the rent
    /// </summary>
    [Column("end")]
    [Required]
    public required DateTime End { get; set; }
    /// <summary>
    /// Rent id
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }
}