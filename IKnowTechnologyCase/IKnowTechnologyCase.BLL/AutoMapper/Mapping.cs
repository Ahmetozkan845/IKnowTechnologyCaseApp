using AutoMapper;
using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Models.VMs;
using IKnowTechnologyCase.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap().ForAllMembers(a => a.UseDestinationValue());
            CreateMap<Notebook, UpdateNoteDTO>().ReverseMap().ForAllMembers(a => a.UseDestinationValue());
            CreateMap<Notebook, CreateNoteDTO>().ReverseMap().ForAllMembers(a => a.UseDestinationValue());
            CreateMap<Notebook, GetNoteVM>().ReverseMap().ForAllMembers(a => a.UseDestinationValue());
        }
    }
}
