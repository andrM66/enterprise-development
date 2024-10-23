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
    // GET: api/<BikeTypeController>
    [HttpGet]
    public ActionResult<IEnumerable<BikeType>> Get() => Ok(repository.GetAll());

    // GET api/<BikeTypeController>/5
    [HttpGet("{id}")]
    public ActionResult<BikeType> Get(int id) => Ok(repository.GetById(id));


    // POST api/<BikeTypeController>
    [HttpPost]
    public IActionResult Post([FromBody] BikeTypeDto value)
    {
        var bikeType = mapper.Map<BikeType>(value);
        repository.Post(bikeType);
        return Ok();
    }

    // PUT api/<BikeTypeController>/5
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

    // DELETE api/<BikeTypeController>/5
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
