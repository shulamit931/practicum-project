using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public class Mapper:Profile
    {
        public Mapper() 
        {
            CreateMap<PersonDTO,Person>().ReverseMap();
            CreateMap<EHMO,EHMODTO>().ReverseMap();
            CreateMap<EKind,EKindDTO>().ReverseMap();
        }
    }
}
