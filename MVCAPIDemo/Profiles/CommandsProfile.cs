using AutoMapper;
using MVCAPIDemo.DTOs;
using MVCAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIDemo.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source to Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
