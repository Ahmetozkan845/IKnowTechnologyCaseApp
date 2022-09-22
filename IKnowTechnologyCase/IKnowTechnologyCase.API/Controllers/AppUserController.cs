using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Models.VMs;
using IKnowTechnologyCase.BLL.Services.NotebookService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly INotebookService notebookService;

        public AppUserController(INotebookService notebookService)
        {
            this.notebookService = notebookService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteDTO model)
        {
            await notebookService.AddNewNotebook(model);
            return Ok();

        }
      
        [HttpGet,Route("{id}")]
        public async Task<IActionResult> GetNotes(string id)
        {
            List<GetNoteVM> notes=await notebookService.GetNotes(id);   
            return Ok(notes);
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUpdateNote(int id)
        {
            UpdateNoteDTO updateNoteDTO = await notebookService.GetById(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNote(UpdateNoteDTO model)
        {
            bool result =await notebookService.UpdateNotebook(model);
            if(result)
            {
                return Ok();
            }
            return BadRequest();


        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetDeleteNote(int id)
        {
            
            GetNoteVM getNoteVM = await notebookService.GetNoteById(id);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteNote(GetNoteVM model)
        {
            bool result = await notebookService.DeleteNotebook(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();


        }

    }
}
