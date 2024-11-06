using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using BikeRent.Server.Dto;
using AutoMapper;

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
    public ActionResult<IEnumerable<Client>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id) => Ok(repository.GetById(id));

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public IActionResult Post([FromBody] ClientDto value)
    {
        var client = mapper.Map<Client>(value);
        repository.Post(client);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientDto value)
    {
        var client = mapper.Map<Client>(value);
        if(!repository.Put(client, id))
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
    public IActionResult Delete(int id)
    {
        if(!repository.Delete(id))
        {
            return NotFound();
        }
        return Ok();
    }
}
