using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;


namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeController(IRepository<Bike, int> repository) : ControllerBase
{
    // GET: api/<ValuesController>
    [HttpGet]
    public ActionResult<IEnumerable<Bike>> Get() => Ok(repository.GetAll());

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public ActionResult<Bike> Get(int id) => Ok(repository.GetById(id));

    // POST api/<ValuesController>
    [HttpPost]
    public IActionResult Post([FromBody] Bike value)
    {
        repository.Post(value);
        return Ok();
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Bike value)
    {
        if (!repository.Put(value, id))
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
