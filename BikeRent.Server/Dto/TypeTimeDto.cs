namespace BikeRent.Server.Dto;

public class TypeTimeDto
{
    /// <summary>
    /// Type's name
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Total rent time for sertain bike type
    /// </summary>
    public required TimeSpan Time { get; set; }
}

