using BussinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("note")]
[Authorize]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(string text)
    {
        await noteService.CreateAsync(text);
        return NoContent();
    }


    [HttpGet(template: "{id:int}")]
    public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
    {
        var result = await noteService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut(template: "{id:int}")]
    public async Task<IActionResult> UpdateNoteAsync([FromRoute] int id, [FromBody] string newText)
    {
        await noteService.UpdateAsync(id, newText);
        return NoContent();
    }

    [HttpDelete(template: "{id:int}")]
    public async Task<IActionResult> DeleteNoteAsync([FromRoute] int id)
    {
        await noteService.DeleteAsync(id);
        return NoContent();
    }
}