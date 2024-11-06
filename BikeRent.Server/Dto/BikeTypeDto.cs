namespace BikeRent.Server.Dto;

public class BikeTypeDto
{
    /// <summary>
    /// Rental cost
    /// </summary>
    public required double Price { get; set; }
    /// <summary>
    /// Type's name
    /// </summary>
    public required string Name { get; set; }
}
