using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using AutoMapper;
using Server.Dto;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentController(IRepository<Rent, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all objects
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Rent>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Rent> Get(int id) => Ok(repository.GetById(id));

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public IActionResult Post([FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        repository.Post(rent);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        if (!repository.Put(rent, id))
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
