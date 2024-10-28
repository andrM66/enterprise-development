using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using AutoMapper;
using Server.Dto;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BikeRent.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RequestTaskController(IRepository<Client, int> clientRepository,
                                   IRepository<Bike, int> bikeRepository,
                                   IRepository<BikeType, int> bikeTypeRepository,
                                   IRepository<Rent, int> rentRepository,
                                   IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Fixture
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostData()
    {
        List<ClientDto> Clients =
        [
           new(){ FirstName = "Vasily", SecondName = "Denisov", Patronymic = "Nikolayevich", BirthDate = new DateTime(1970, 7, 20), PhoneNumber = "+7 908 216 48 93"},
            new(){ FirstName = "Alexandr", SecondName = "Katkov", Patronymic = "Dmitrievich", BirthDate = new DateTime(1984, 11, 14), PhoneNumber = "+7 908 156 38 26"},
            new(){ FirstName = "George", SecondName = "Granitov", Patronymic = "Albertovich", BirthDate = new DateTime(2001, 3, 30), PhoneNumber = "+7 907 511 63 89"},
            new(){ FirstName = "Alexey", SecondName = "Kuznetsov", Patronymic = "Vasilievich", BirthDate = new DateTime(2005, 5, 17), PhoneNumber = "+7 908 312 58 50"},
            new(){ FirstName = "Vyacheslav", SecondName = "Gvozdev", Patronymic = "Andreevich", BirthDate = new DateTime(1993, 1, 1), PhoneNumber = "+7 908 333 65 32"},
            new(){ FirstName = "Vsevolod", SecondName = "Arshinov", Patronymic = "Vladimirivoch", BirthDate = new DateTime(1999, 12, 21), PhoneNumber = "+7 905 041 32 61"},
            new(){ FirstName = "Ratibor", SecondName = "Zaharov", Patronymic = "Viktorovich", BirthDate = new DateTime(1975, 9, 18), PhoneNumber = "+7 908 216 18 97"}
        ];
        List<BikeTypeDto> Types =
        [
                new(){ Price = 300, Name = "Sport"},
                new(){ Price = 350, Name = "Mountain"},
                new(){ Price = 250, Name = "Walking"}
        ];
        List<BikeDto> Bikes =
        [
                new(){Color = "Blue", Model = "003v5", TypeId = 0 },
                new(){Color = "Red", Model = "003b", TypeId = 1 },
                new(){Color = "Black", Model = "004v8", TypeId = 2 },
                new(){Color = "Yellow", Model = "01006n", TypeId= 2 },
                new(){Color = "Green", Model = "331h", TypeId = 1},
                new(){Color = "Violet", Model = "34rf", TypeId = 1},
                new(){Color = "Orange", Model = "0004f", TypeId = 0}
        ];
        List<RentDto> Rents =
        [
                new(){ClientId = 0, BikeId = 4, Begin = new DateTime(2023, 9, 20, 18, 31, 0 ), End = new DateTime(2023, 9, 20, 20, 0, 0)},
                new(){ClientId = 0, BikeId = 3, Begin = new DateTime(2023, 9, 27, 17, 30, 0 ), End = new DateTime(2023, 9, 27, 19, 0, 0)},
                new(){ClientId = 0, BikeId = 3, Begin = new DateTime(2023, 9, 13, 17, 24, 0 ), End = new DateTime(2023, 9, 13, 19, 30, 0)},
                new(){ClientId = 0, BikeId = 3, Begin = new DateTime(2023, 9, 6, 18, 5, 0 ), End = new DateTime(2023, 9, 6, 19, 30, 0)},
                new(){ClientId = 0, BikeId = 4, Begin = new DateTime(2023, 9, 14, 18, 13, 0 ), End = new DateTime(2023, 9, 14, 19, 40, 0)},
                new(){ClientId = 0, BikeId = 2, Begin = new DateTime(2023, 9, 7, 17, 49, 0 ), End = new DateTime(2023, 9, 7, 19, 0, 0)},
                new(){ClientId = 1, BikeId = 2, Begin = new DateTime(2023, 9, 1, 18, 0, 0 ), End = new DateTime(2023, 9, 1, 20, 0, 0)},
                new(){ClientId = 1, BikeId = 2, Begin = new DateTime(2023, 9, 8, 16, 55, 0 ), End = new DateTime(2023, 9, 8, 20, 0, 0)},
                new(){ClientId = 1, BikeId = 4, Begin = new DateTime(2023, 9, 3, 18, 31, 0 ), End = new DateTime(2023, 9, 3, 20, 0, 0)},
                new(){ClientId = 1, BikeId = 1, Begin = new DateTime(2023, 9, 16, 14, 0, 0 ), End = new DateTime(2023, 9, 16, 16, 30, 0)},
                new(){ClientId = 1, BikeId = 1, Begin = new DateTime(2023, 9, 22, 15, 30, 0 ), End = new DateTime(2023, 9, 22, 16, 0, 0)},
                new(){ClientId = 1, BikeId = 1, Begin = new DateTime(2023, 9, 6, 18, 33, 0 ), End = new DateTime(2023, 9, 6, 20, 10, 0)},
                new(){ClientId = 2, BikeId = 4, Begin = new DateTime(2023, 9, 11, 18, 20, 0 ), End = new DateTime(2023, 9, 11, 20, 15, 0)},
                new(){ClientId = 2, BikeId = 5, Begin = new DateTime(2023, 9, 23, 13, 40, 0 ), End = new DateTime(2023, 9, 23, 15, 20, 0)},
                new(){ClientId = 3, BikeId = 5, Begin = new DateTime(2023, 9, 5, 14, 35, 0 ), End = new DateTime(2023, 9, 5, 15, 30, 0)},
                new(){ClientId = 3, BikeId = 5, Begin = new DateTime(2023, 9, 5, 19, 0, 0 ), End = new DateTime(2023, 9, 5, 21, 20, 0)},
                new(){ClientId = 3, BikeId = 4, Begin = new DateTime(2023, 9, 6, 9, 0, 0 ), End = new DateTime(2023, 9, 6, 11, 0, 0)},
                new(){ClientId = 3, BikeId = 6, Begin = new DateTime(2023, 9, 8, 8, 40, 0 ), End = new DateTime(2023, 9, 8, 10, 20, 0)},
                new(){ClientId = 4, BikeId = 6, Begin = new DateTime(2023, 9, 11, 11, 31, 0 ), End = new DateTime(2023, 9, 11, 13, 0, 0)},
                new(){ClientId = 4, BikeId = 6, Begin = new DateTime(2023, 9, 14, 10, 0, 0 ), End = new DateTime(2023, 9, 14, 12, 30, 0)},
                new(){ClientId = 5, BikeId = 4, Begin = new DateTime(2023, 9, 13, 13, 50, 0 ), End = new DateTime(2023, 9, 13, 16, 0, 0)},
                new(){ClientId = 4, BikeId = 1, Begin = new DateTime(2023, 9, 30, 15, 13, 0 ), End = new DateTime(2023, 9, 30, 18, 0, 0)},
                new(){ClientId = 5, BikeId = 1, Begin = new DateTime(2023, 9, 5, 16, 44, 0 ), End = new DateTime(2023, 9, 5, 18, 0, 0)},
                new(){ClientId = 6, BikeId = 1, Begin = new DateTime(2023, 9, 23, 12, 1, 0 ), End = new DateTime(2023, 9, 23, 14, 14, 0)},
                new(){ClientId = 5, BikeId = 4, Begin = new DateTime(2023, 9, 21, 15, 31, 0 ), End = new DateTime(2023, 9, 21, 16, 0, 0)},
                new(){ClientId = 6, BikeId = 3, Begin = new DateTime(2023, 9, 22, 13, 31, 0 ), End = new DateTime(2023, 9, 22, 15, 0, 0)},
                new(){ClientId = 5, BikeId = 3, Begin = new DateTime(2023, 9, 1, 12, 31, 0 ), End = new DateTime(2023, 9, 1, 13, 0, 0)},
          ];
        foreach(ClientDto client in Clients)
        {
            clientRepository.Post(mapper.Map<Client>(client));
        }
        foreach(BikeTypeDto type in Types)
        {
            bikeTypeRepository.Post(mapper.Map<BikeType>(type));
        }
        foreach(BikeDto bike in Bikes)
        {
            bikeRepository.Post(mapper.Map<Bike>(bike));
        }
        foreach(RentDto rent in Rents)
        {
            rentRepository.Post(mapper.Map<Rent>(rent));
        }
        return Ok();
    }
    /// <summary>
    /// Request from 0 to 5
    /// </summary>
    /// <param name="task">request num (0 to 5)</param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Requests(int task)
    {
        var clients = clientRepository.GetAll();
        var bikes = bikeRepository.GetAll();
        var types = bikeTypeRepository.GetAll();
        var rents = rentRepository.GetAll();
        switch (task)
        {
            case 0:
                var sport = (from type in types
                             where type.Name == "Sport"
                             join bike in bikes on type.Id equals bike.TypeId
                             select bike).ToList();
                return Ok(sport);
            case 1:
                var mountainClients = (from type in types
                                       where type.Name == "Mountain"
                                       join bike in bikes on type.Id equals bike.TypeId
                                       join rent in rents on bike.Id equals rent.BikeId
                                       join client in clients on rent.ClientId equals client.Id
                                       orderby client.SecondName, client.FirstName, client.Patronymic
                                       select client).Distinct().ToList();

                return Ok(mountainClients);
            case 2:
                var typeRentTime = (from type in types
                                    join bike in bikes on type.Id equals bike.TypeId
                                    join rent in rents on bike.Id equals rent.BikeId
                                    group new { rent, type } by type.Id into newRents
                                    select new
                                    {
                                        newRents.Key,
                                        Time = TimeSpan.FromSeconds(newRents.Sum(rn => rn.rent.End.Subtract(rn.rent.Begin).TotalSeconds))
                                    }).ToList();
                return Ok(typeRentTime);
            case 3:
                var rentCountedClients = (from rent in rents
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
                var mostRentClients = (from client in rentCountedClients
                                       where client.Count == rentCountedClients.Max(rt => rt.Count)
                                       select client).ToList();
                return Ok(mostRentClients);
            case 4:
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

                    return Ok(bikeRent);
            case 5:
                var max = rents.Max(r => r.End - r.Begin).TotalSeconds;
                var min = rents.Min(r => r.End - r.Begin).TotalSeconds;
                var avg = rents.Average(r => (r.End - r.Begin).TotalSeconds);

                if (Math.Abs(11100 - max) < 1 && Math.Abs(1740 - min) < 1 && Math.Abs(6091 - avg) < 1)
                {
                   return Ok();
                }
                return NotFound();
        }
        return NoContent();
    }
}
