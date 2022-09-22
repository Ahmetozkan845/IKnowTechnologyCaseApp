using AutoMapper;
using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Models.VMs;
using IKnowTechnologyCase.CORE.Entities;
using IKnowTechnologyCase.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Services.NotebookService
{
    public class NotebookService : INotebookService
    {
        private readonly IMapper mapper;
        private readonly INotebookRepository notebookRepository;

        public NotebookService(IMapper mapper, INotebookRepository notebookRepository)
        {
            this.mapper = mapper;
            this.notebookRepository = notebookRepository;
        } 
        public async Task<bool> AddNewNotebook(CreateNoteDTO noteDTO)
        {
            Notebook notebook = new Notebook();
            notebook = mapper.Map(noteDTO, notebook);
            await notebookRepository.Create(notebook);
            return true;
        }

        public async Task<bool> DeleteNotebook(GetNoteVM getNoteVM)
        {
            var note = await notebookRepository.GetWhere(a=>a.Id == getNoteVM.Id);
            notebookRepository.Delete(note);  
            return true;
            
        }

        public async Task<UpdateNoteDTO> GetById(int id)
        {
            var note = await notebookRepository.GetFilteredFirstOrDefault(
                selector: a => new UpdateNoteDTO
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description
                },
                expression: a => a.Id == id && a.IsActive == true
                
                );
            return note;
        }

        public async Task<GetNoteVM> GetNoteById(int id)
        {
            var note = await notebookRepository.GetWhere(a => a.Id == id);
            GetNoteVM vm = new GetNoteVM();
            vm= mapper.Map(note, vm);
            return vm;
          
        }

        public async Task<List<GetNoteVM>> GetNotes(string UserId)
        {
            var notes = await notebookRepository.GetFilteredList(
                selector: a => new GetNoteVM
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    CreationDate = a.CreationDate

                },
                expression: a => a.IsActive != false && a.UserId == UserId,
                orderBy: a => a.OrderByDescending(a => a.CreationDate)
                );
            return notes;
        }

        public async Task<bool> UpdateNotebook(UpdateNoteDTO updateNote)
        {
            Notebook notebook = await notebookRepository.GetWhere(a => a.Id == updateNote.Id);
            if(notebook != null)
            {
                notebook = mapper.Map(updateNote, notebook);
                return notebookRepository.Update(notebook);
            }
            else
            {
                return false;
            }
            
           
            
        }
        
    }
}
