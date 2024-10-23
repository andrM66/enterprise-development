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
    // GET: api/<RentController>
    [HttpGet]
    public ActionResult<IEnumerable<Rent>> Get() => Ok(repository.GetAll());

    // GET api/<RentController>/5
    [HttpGet("{id}")]
    public ActionResult<Rent> Get(int id) => Ok(repository.GetById(id));


    // POST api/<RentController>
    [HttpPost]
    public IActionResult Post([FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        repository.Post(rent);
        return Ok();
    }

    // PUT api/<RentController>/5
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

    // DELETE api/<RentController>/5
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
