namespace Server.Dto;

public class ClientDto
{
    /// <summary>
    /// Client's first name
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Client's second name
    /// </summary>
    public required string SecondName { get; set; }
    /// <summary>
    /// Client's Patronymic
    /// </summary>
    public required string Patronymic { get; set; }
    /// <summary>
    /// Client's birth date
    /// </summary>
    public required DateTime BirthDate { get; set; }
    /// <summary>
    /// Client's phone number
    /// </summary>
    public required string PhoneNumber { get; set; }
}
