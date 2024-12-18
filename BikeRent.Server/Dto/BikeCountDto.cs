namespace BikeRent.Server.Dto;

public class BikeCountDto
{
    /// <summary>
    /// Bike Id
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Bike model
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Bike color
    /// </summary>
    public required string Color { get; set; }
    /// <summary>
    /// Nuber of bikes
    /// </summary>
    public required int Count { get; set; }
}
