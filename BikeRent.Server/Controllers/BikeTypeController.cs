using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using AutoMapper;
using BikeRent.Server.Dto;
using BikeRent.Domain.Entities;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeTypeController(IRepository<BikeType, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BikeType>>> Get()
    {
        var bikeTypes = await repository.GetAllAsync();
        return Ok(bikeTypes);
    }

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    // GET api/<BikeTypeController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BikeType>> Get(int id)
    {
        var bikeType = await repository.GetByIdAsync(id);
        if (bikeType == null)
        {
            return NotFound();
        }
        return Ok(bikeType);
    }

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BikeTypeDto value)
    {
        var bikeType = mapper.Map<BikeType>(value);
        await repository.PostAsync(bikeType);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BikeTypeDto value)
    {
        var bikeType = mapper.Map<BikeType>(value);
        var putFlag = await repository.PutAsync(bikeType, id);
        if(!putFlag)
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
