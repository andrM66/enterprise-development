namespace BikeRent.Server.Dto;

public class RentDto
{
    /// <summary>
    /// Client's id
    /// </summary>
    public required int ClientId { get; set; }
    /// <summary>
    /// Bike's id
    /// </summary>
    public required int BikeId { get; set; }
    /// <summary>
    /// Start of the rent
    /// </summary>
    public required DateTime Begin { get; set; }
    /// <summary>
    /// End of the rent
    /// </summary>
    public required DateTime End { get; set; }
}
