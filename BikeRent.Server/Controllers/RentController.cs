using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using AutoMapper;
using BikeRent.Server.Dto;
using BikeRent.Domain.Entities;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentController(IRepository<Rent, int> repository, IRepository<Client, int> clientRepository, IRepository<Bike, int> bikeRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rent>>> Get()
    {
        var rents = await repository.GetAllAsync();
        return Ok(rents);
    }

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Rent>> Get(int id)
    {
        var rent = repository.GetByIdAsync(id);
        if(rent == null)
        {
            return NotFound();
        }
        return Ok(rent);
    }

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RentDto value)
    {
        var bike = await bikeRepository.GetByIdAsync(value.BikeId);
        var client = await clientRepository.GetByIdAsync(value.ClientId);
        if(bike == null || client == null)
        {
            return NotFound();
        }
        var rent = mapper.Map<Rent>(value);
        await repository.PostAsync(rent);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RentDto value)
    {
        var client = await clientRepository.GetByIdAsync(value.ClientId);
        var bike = await bikeRepository.GetByIdAsync(value.BikeId);
        if(bike == null || client == null)
        {
            return NotFound();
        }
        var rent = mapper.Map<Rent>(value);
        var putFlag = await repository.PutAsync(rent, id);
        if (!putFlag)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Delete sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteFlag = await repository.DeleteAsync(id);
        if(!deleteFlag)
        {
            return NotFound();
        }
        return Ok();
    }
}
