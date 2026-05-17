using Microsoft.AspNetCore.Mvc;
using PC_CodeFirst.DTOs;
using PC_CodeFirst.Services;
using PC_CodeFirst.Exceptions;

namespace PC_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PCsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PCsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    // GET api/pcs
    [HttpGet]
    public async Task<IActionResult> GetAllPCs()
    {
        var result = await _dbService.GetAllComputersAsync();

        return Ok(result);
    }

    // GET api/pcs/{id}/components
    [Route("{id:int}/components")]
    [HttpGet]
    public async Task<IActionResult> GetCompByPcId(int id)
    {
        try
        {
            var result = await _dbService.GetCompByPcIdAsync(id);

            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    // POST api/pcs
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateNewComputerDto dto)
    {
        var result = await _dbService.CreateNewComputerAsync(dto);

        return CreatedAtAction(nameof(GetCompByPcId), new { id = result.Id }, result);
    }

    // PUT api/pcs/{id}
    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateComputerByIdDto dto)
    {
        try
        {
            await _dbService.UpdateComputerAsync(id, dto);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    // DELETE api/pcs/{id}
    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _dbService.DeleteComputerAsync(id);

            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}