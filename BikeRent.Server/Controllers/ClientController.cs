using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain.Repositories;
using BikeRent.Server.Dto;
using AutoMapper;
using BikeRent.Domain.Entities;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController(IRepository<Client, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> Get()
    {
        var clients = await repository.GetAllAsync();
        return Ok(clients);
    }

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(int id)
    {
        var client = await repository.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientDto value)
    {
        var client = mapper.Map<Client>(value);
        await repository.PostAsync(client);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClientDto value)
    {
        var client = mapper.Map<Client>(value);
        var putFlag = await repository.PutAsync(client, id);
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
