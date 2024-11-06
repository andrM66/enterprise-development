namespace BikeRent.Server.Dto;

public class BikeDto
{
    /// <summary>
    /// Bike's type's id
    /// </summary>
    public required int TypeId { get; set; }
    /// <summary>
    /// Bike's model
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Bike's color
    /// </summary>
    public required string Color { get; set; }
}
