using BussinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Note_Api_Bra_addition.DTO.Auth;
using Note_Api_Bra_addition.DTO.Notes;
using System.Security.Claims;

namespace WebApi;

[ApiController]
[Route("note")]
[Authorize]
public class NoteController(INoteService noteService) : ControllerBase
{
    // Метод для получения PersonId
    private int GetCurrentPersonId()
    {
        // User - это свойство ControllerBase, заполненное из токена
        var claim = User.FindFirst("personId") ?? User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
            throw new UnauthorizedAccessException("Пользователь не аутентифицирован");

        return int.Parse(claim.Value);
    }

    [HttpPost]
    //public async Task<IActionResult> CreateAsync(string text)
    public async Task<IActionResult> CreateAsync([FromBody] CreateNoteDto createdto)
    {
        var personId = GetCurrentPersonId();
        await noteService.CreateAsync(createdto.Text, personId);
        return NoContent();
    }

    // до связи пользователя и заметок
    //[HttpGet(template: "{id:int}")]
    //public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
    ////public async Task<IActionResult> GetNoteAsync([FromBody] UpdateNoteDto updatedto)
    //{
    //    var result = await noteService.GetByIdAsync(id);
    //    return Ok(result);
    //}

    //[HttpPut(template: "{id:int}")]
    //public async Task<IActionResult> GetNoteAsync([FromBody] UpdateNoteDto updatedto)
    ////public async Task<IActionResult> UpdateNoteAsync([FromRoute] int id, [FromBody] string newText)
    //{
    //    await noteService.UpdateAsync(updatedto.Id, updatedto.Text);
    //    return NoContent();
    //}

    //[HttpDelete(template: "{id:int}")]
    //public async Task<IActionResult> DeleteNoteAsync([FromRoute] int id)
    //{
    //    await noteService.DeleteAsync(id);
    //    return NoContent();
    //}


    [HttpGet]
    public async Task<ActionResult<List<NoteResponseDto>>> GetMyNotes()
    {
        var personId = GetCurrentPersonId(); // Например: 5

        // 3. Сервис использует personId для фильтрации
        var notes = await noteService.GetPersonNotesAsync(personId);

        return Ok(notes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNoteDto dto)
    {
        var personId = GetCurrentPersonId();

        // 4. В сервисе можно проверить, что заметка принадлежит пользователю
        await noteService.UpdateNoteAsync(id, dto.Text, personId);

        return NoContent();
    }


}