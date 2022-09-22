using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Services.NotebookService
{
    public interface INotebookService 
    {
        Task<bool> AddNewNotebook(CreateNoteDTO noteDTO);
        Task<bool> UpdateNotebook(UpdateNoteDTO updateNote);
        Task<bool> DeleteNotebook(GetNoteVM getNoteVM);
        Task<List<GetNoteVM>> GetNotes(string UserId);
        Task<UpdateNoteDTO> GetById(int id);
        Task<GetNoteVM> GetNoteById(int id);

    }
}
