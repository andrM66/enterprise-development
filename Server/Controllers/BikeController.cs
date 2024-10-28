using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using AutoMapper;
using Server.Dto;


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
    public ActionResult<IEnumerable<Bike>> Get() => Ok(repository.GetAll());

    /// <summary>
    /// Get sertain object
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Bike> Get(int id) => Ok(repository.GetById(id));

    /// <summary>
    /// Post object
    /// </summary>
    /// <param name="value">object's dto</param>
    [HttpPost]
    public IActionResult Post([FromBody] BikeDto value)
    {
        if(bikeTypeRepository.GetById(value.TypeId) == null)
        {
            return NotFound();
        }
        var bike = mapper.Map<Bike>(value);
        repository.Post(bike);
        return Ok();
    }

    /// <summary>
    /// Update sertain object
    /// </summary>
    /// <param name="value">object's dto</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] BikeDto value)
    {
        if(bikeTypeRepository.GetById(value.TypeId) == null)
        {
            return NotFound();
        }
        var bike = mapper.Map<Bike>(value);
        if (!repository.Put(bike, id))
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
