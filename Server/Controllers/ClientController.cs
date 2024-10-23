using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;
using Server.Dto;
using AutoMapper;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController(IRepository<Client, int> repository, IMapper mapper) : ControllerBase
{
    // GET: api/<ClientController>
    [HttpGet]
    public ActionResult<IEnumerable<Client>> Get() => Ok(repository.GetAll());

    // GET api/<ClientController>/5
    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id) => Ok(repository.GetById(id));

    // POST api/<ClientController>
    [HttpPost]
    public IActionResult Post([FromBody] ClientDto value)
    {
        var client = mapper.Map<Client>(value);
        repository.Post(client);
        return Ok();
    }

    // PUT api/<ClientController>/5
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

    // DELETE api/<ClientController>/5
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
