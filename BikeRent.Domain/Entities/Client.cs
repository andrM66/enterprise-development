using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRent.Domain.Entities;
/// <summary>
/// Class that represents service's client
/// </summary>
[Table("client")]
public class Client
{
    /// <summary>
    /// Client's id
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// Client's name
    /// </summary>
    [Column("first_name")]
    [Required]  
    public required string FirstName { get; set; }
    /// <summary>
    /// Client's second name
    /// </summary>
    [Column("second_name")]
    [Required]
    public required string SecondName { get; set; }
    /// <summary>
    /// Client's Patronymic
    /// </summary>
    [Column("patronimic")]
    [Required]
    public required string Patronymic { get; set; }
    /// <summary>
    /// Client's birth date
    /// </summary>
    [Column("birth_date")]
    [Required]
    public required DateTime BirthDate { get; set; }
    /// <summary>
    /// Client's phone number
    /// </summary>
    [Column("phone_number")]
    [MaxLength(12)]
    [Required]
    public required string PhoneNumber { get; set; }
}