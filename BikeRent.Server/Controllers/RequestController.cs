using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using AutoMapper;
using BikeRent.Server.Dto;
using BikeRent.Domain.Entities;
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
    public ActionResult<Bike> GetSportBikes()
    {
        var bikes = bikeRepository.GetAll();
        var types = bikeTypeRepository.GetAll();
        var sportBikes =
            (from type in types
             where type.Name == "Sport"
             join bike in bikes on type.Id equals bike.TypeId
             select bike).ToList();
        if(sportBikes == null)
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
    public ActionResult<Client> GetMountainClients()
    {
        var clients = clientRepository.GetAll();
        var bikes = bikeRepository.GetAll();
        var types = bikeTypeRepository.GetAll();
        var rents = rentRepository.GetAll();
        var mountainClients =
            (from type in types
             where type.Name == "Mountain"
             join bike in bikes on type.Id equals bike.TypeId
             join rent in rents on bike.Id equals rent.BikeId
             join client in clients on rent.ClientId equals client.Id
             orderby client.SecondName, client.FirstName, client.Patronymic
             select client).Distinct().ToList();
        if(mountainClients == null)
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
    public ActionResult<TypeTimeDto> GetAllTypesTime()
    {
        var bikes = bikeRepository.GetAll();
        var types = bikeTypeRepository.GetAll();
        var rents = rentRepository.GetAll();

        var typeRentTime =
            (from type in types
             join bike in bikes on type.Id equals bike.TypeId
             join rent in rents on bike.Id equals rent.BikeId
             group new { rent, type } by new { type.Id, type.Name} into newRents
             select new 
             {
                 newRents.Key.Name,
                 Time = TimeSpan.FromSeconds(newRents.Sum(rn => rn.rent.End.Subtract(rn.rent.Begin).TotalSeconds))
             }).ToList();
        if(typeRentTime == null)
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
    public ActionResult<Client> GetTopClients()
    {
        var rents = rentRepository.GetAll();
        var clients = clientRepository.GetAll();

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
        if(mostRentClients == null)
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
    public ActionResult<IEnumerable<Bike>> GetTopBikes()
    {
        var rents = rentRepository.GetAll();
        var bikes = bikeRepository.GetAll();

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
        if(bikeRent == null)
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
    public ActionResult<IEnumerable<TimeSpan>> GetMaxMinAvgTime()
    {
        var rents = rentRepository.GetAll();

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