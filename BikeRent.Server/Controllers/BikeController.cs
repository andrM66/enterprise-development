using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using AutoMapper;
using BikeRent.Server.Dto;
using BikeRent.Domain.Entities;


namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeController(IRepository<Bike, int> repository, IRepository<BikeType, int> bikeTypeRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bike>>> Get()
    {
        var bikes = await repository.GetAllAsync();
        return Ok(bikes);
    }

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Bike>> Get(int id)
    {
        var bike = await repository.GetByIdAsync(id);
        if (bike == null)
        {
            return NotFound();
        }
        return Ok(bike);
    }

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BikeDto value)
    {
        var bikeType = await bikeTypeRepository.GetByIdAsync(value.TypeId);
        if(bikeType == null)
        {
            return NotFound();
        }
        var bike = mapper.Map<Bike>(value);
        await repository.PostAsync(bike);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] BikeDto value)
    {
        var bikeType = await bikeTypeRepository.GetByIdAsync(id);
        if(bikeType == null)
        {
            return NotFound();
        }
        var bike = mapper.Map<Bike>(value);
        var putFlag = await repository.PutAsync(bike, id);
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
