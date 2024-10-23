using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using AutoMapper;
using Server.Dto;


namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeController(IRepository<Bike, int> repository, IMapper mapper) : ControllerBase
{
    // GET: api/<ValuesController>
    [HttpGet]
    public ActionResult<IEnumerable<Bike>> Get() => Ok(repository.GetAll());

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public ActionResult<Bike> Get(int id) => Ok(repository.GetById(id));

    // POST api/<ValuesController>
    [HttpPost]
    public IActionResult Post([FromBody] BikeDto value)
    {
        var bike = mapper.Map<Bike>(value);
        repository.Post(bike);
        return Ok();
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] BikeDto value)
    {
        var bike = mapper.Map<Bike>(value);
        if (!repository.Put(bike, id))
        {
            NotFound();
        }
        return Ok();
    }

    // DELETE api/<ValuesController>/5
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
