using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using AutoMapper;
using Server.Dto;

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
    public ActionResult<IEnumerable<BikeType>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    // GET api/<BikeTypeController>/5
    [HttpGet("{id}")]
    public ActionResult<BikeType> Get(int id) => Ok(repository.GetById(id));

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public IActionResult Post([FromBody] BikeTypeDto value)
    {
        var bikeType = mapper.Map<BikeType>(value);
        repository.Post(bikeType);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BikeTypeDto value)
    {
        var bikeType = mapper.Map<BikeType>(value);
        if(!repository.Put(bikeType, id))
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
