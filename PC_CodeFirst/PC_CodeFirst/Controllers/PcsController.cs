using Microsoft.AspNetCore.Mvc;
using PC_CodeFirst.Entities;
using PC_CodeFirst.Services;

namespace PC_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PcsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    // GET api/pcs
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    // GET api/pcs/{id}/components
    [Route("{id:int}/components")]
    public async Task<IActionResult> Get(int id)
    {
        throw new NotImplementedException();
    }

    // POST api/pcs
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pc pc)
    {
        throw new NotImplementedException();
    }

    // PUT api/pcs/{id}
    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] Pc pc)
    {
        throw new NotImplementedException();
    }

    // DELETE api/pcs/{id}
    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }
}