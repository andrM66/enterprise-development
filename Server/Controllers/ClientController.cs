﻿using Microsoft.AspNetCore.Mvc;
using BikeRent.Domain;
using BikeRent.Domain.Repositories;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController(IRepository<Client, int> repository) : ControllerBase
{
    // GET: api/<ClientController>
    [HttpGet]
    public ActionResult<IEnumerable<Client>> Get() => Ok(repository.GetAll());

    // GET api/<ClientController>/5
    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id) => Ok(repository.GetById(id));

    // POST api/<ClientController>
    [HttpPost]
    public IActionResult Post([FromBody] Client value)
    {
        repository.Post(value);
        return Ok();
    }

    // PUT api/<ClientController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Client value)
    {
        if(!repository.Put(value, id))
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