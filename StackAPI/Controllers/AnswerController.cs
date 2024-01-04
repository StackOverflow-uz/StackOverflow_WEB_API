using DTOs.AnswerD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StackAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController(IAnswerService answerService) : ControllerBase
{
    private readonly IAnswerService _answerService = answerService;
    [HttpGet("getall")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _answerService.GetAll();
            var json = JsonConvert.SerializeObject(categories,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
            return Ok(json);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("paged")]
    public async Task<IActionResult> Get(int pageSize = 10, int pageNumber = 1)
    {
        try
        {
            var categories = await _answerService.GetAllPaged(pageSize, pageNumber);
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _answerService.GetById(id);
            return Ok(category);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(AddAnswerDto dto)
    {
        try
        {
            await _answerService.Add(dto);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (StackException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(UpdateAnswerDto dto)
    {
        try
        {
            await _answerService.Update(dto);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (StackException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _answerService.Delete(id);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
