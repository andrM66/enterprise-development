namespace BikeRent.Server.Dto;

public class TimeStatDto
{
    /// <summary>
    /// Max rental time
    /// </summary>
    public TimeSpan Maximum { get; set; }
    /// <summary>
    /// Min rental time
    /// </summary>
    public TimeSpan Minimum { get; set; }
    /// <summary>
    /// Average rental time
    /// </summary>
    public TimeSpan Average { get; set; }
}
