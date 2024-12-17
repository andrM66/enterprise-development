using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using BikeRent.Domain.Entities;
using BikeRent.Server.Dto;

namespace BikeRent.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestTaskController(IRepository<Client, int> clientRepository,
                                   IRepository<Bike, int> bikeRepository,
                                   IRepository<BikeType, int> bikeTypeRepository,
                                   IRepository<Rent, int> rentRepository) : ControllerBase
{
    /// <summary>
    /// Get all sport bikes
    /// </summary>
    /// <returns></returns>
    [HttpGet("sportBikes")]
    public async Task<ActionResult<IEnumerable<Bike>>> GetSportBikes()
    {
        var bikes = await bikeRepository.GetAllAsync();
        var types = await bikeTypeRepository.GetAllAsync();
        var sportBikes =
            (from type in types
             where type.Name == "Sport"
             join bike in bikes on type.Id equals bike.TypeId
             select bike).ToList();
        if (sportBikes == null)
        {
            return NotFound();
        }
        return Ok(sportBikes);
    }
    /// <summary>
    /// Get every client who had ever took mountain bike
    /// </summary>
    /// <returns></returns>
    [HttpGet("mountainBikeClients")]
    public async Task<ActionResult<IEnumerable<Client>>> GetMountainClients()
    {
        var clients = await clientRepository.GetAllAsync();
        var bikes = await bikeRepository.GetAllAsync();
        var types = await bikeTypeRepository.GetAllAsync();
        var rents = await rentRepository.GetAllAsync();
        var mountainClients =
            (from type in types
             where type.Name == "Mountain"
             join bike in bikes on type.Id equals bike.TypeId
             join rent in rents on bike.Id equals rent.BikeId
             join client in clients on rent.ClientId equals client.Id
             orderby client.SecondName, client.FirstName, client.Patronymic
             select client).Distinct().ToList();
        if (mountainClients == null)
        {
            return NotFound();
        }
        return Ok(mountainClients);
    }
    /// <summary>
    /// Get total time every bike type have been being rented
    /// </summary>
    /// <returns></returns>
    [HttpGet("typesTime")]
    public async Task<ActionResult<IEnumerable<TypeTimeDto>>> GetAllTypesTime()
    {
        var bikes = await bikeRepository.GetAllAsync();
        var types = await bikeTypeRepository.GetAllAsync();
        var rents = await rentRepository.GetAllAsync();

        var typeRentTime =
            (from type in types
             join bike in bikes on type.Id equals bike.TypeId
             join rent in rents on bike.Id equals rent.BikeId
             group new { rent, type } by new { type.Id, type.Name } into newRents
             select new
             {
                 newRents.Key.Name,
                 Time = TimeSpan.FromSeconds(newRents.Sum(rn => rn.rent.End.Subtract(rn.rent.Begin).TotalSeconds))
             }).ToList();
        if (typeRentTime == null)
        {
            return NotFound();
        }
        return Ok(typeRentTime);
    }
    /// <summary>
    /// Get clients who have rented bikes most times
    /// </summary>
    /// <returns></returns>
    [HttpGet("topClients")]
    public async Task<ActionResult<IEnumerable<Client>>> GetTopClients()
    {
        var rents = await rentRepository.GetAllAsync();
        var clients = await clientRepository.GetAllAsync();

        var rentCountedClients =
            (from rent in rents
             group rent by rent.ClientId into newRents
             from rent in newRents
             join client in clients on rent.ClientId equals client.Id
             select new
             {
                 client.Id,
                 client.FirstName,
                 client.SecondName,
                 client.Patronymic,
                 client.PhoneNumber,
                 client.BirthDate,
                 Count = newRents.Count()
             }).Distinct().ToList();
        var mostRentClients =
            (from client in rentCountedClients
             where client.Count == rentCountedClients.Max(rt => rt.Count)
             select client).ToList();
        if (mostRentClients == null)
        {
            return NotFound();
        }
        return Ok(mostRentClients);
    }
    /// <summary>
    /// Get five bikes that have been rented most times
    /// </summary>
    /// <returns></returns>
    [HttpGet("topFiveBikes")]
    public async Task<ActionResult<IEnumerable<Bike>>> GetTopBikes()
    {
        var rents = await rentRepository.GetAllAsync();
        var bikes = await bikeRepository.GetAllAsync();

        var bikeRent =
            (from rent in rents
             join bike in bikes on rent.BikeId equals bike.Id
             group new { rent, bike } by new { rent.BikeId, bike.Model, bike.Color } into newRents
             orderby newRents.Count() descending
             select new
             {
                 newRents.Key.BikeId,
                 newRents.Key.Model,
                 newRents.Key.Color,
                 Count = newRents.Count(),
             }).Take(5).ToList();
        if (bikeRent == null)
        {
            return NotFound();
        }
        return Ok(bikeRent);
    }
    /// <summary>
    /// Get maximum, minimum and average rental time
    /// </summary>
    /// <returns></returns>
    [HttpGet("rentStats")]
    public async Task<ActionResult<IEnumerable<TimeSpan>>> GetMaxMinAvgTime()
    {
        var rents = await rentRepository.GetAllAsync();

        var max = rents.Max(r => r.End - r.Begin).TotalSeconds;
        var min = rents.Min(r => r.End - r.Begin).TotalSeconds;
        var avg = rents.Average(r => (r.End - r.Begin).TotalSeconds);

        var maxTime = TimeSpan.FromSeconds(max);
        var minTime = TimeSpan.FromSeconds(min);
        var avgTime = TimeSpan.FromSeconds(avg);
        List<TimeSpan> res = [maxTime, minTime, avgTime];
        if (res == null)
        {
            return NotFound(res);
        }
        return Ok(res);
    }
}