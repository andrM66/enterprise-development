using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    // GET: api/<ClientController>
    [HttpGet]
    public IEnumerable<Client> Get()
    {
        return null;
    }

    // GET api/<ClientController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ClientController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ClientController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ClientController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
