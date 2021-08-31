using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCAPIDemo.Data;
using MVCAPIDemo.DTOs;
using MVCAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIDemo.Controllers
{
    // How you get to the resources
    [Route("api/commands")]
    //Out of box behaviours our controller will perform
    [ApiController]
    public class CommandsController : ControllerBase
    {
        //    private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        private readonly ICommanderRepository _repository;
        private readonly IMapper _maper;

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _maper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandsItems = _repository.GetAllCommands();

            return Ok(_maper.Map<IEnumerable<CommandReadDto>>(commandsItems));
        }
        //Give us a route to this: api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_maper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _maper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            return Ok();
        }
    }
}
