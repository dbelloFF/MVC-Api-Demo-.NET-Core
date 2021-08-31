using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MVCAPIDemo.Data;
using MVCAPIDemo.DTOs;
using MVCAPIDemo.Models;
using System.Collections.Generic;

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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem != null)
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

            // We pass a DTO to the payload 
            var commandReadDto = _maper.Map<CommandReadDto>(commandModel);

            // Returns a 201 created
            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);

            //return Ok(commandReadDto);
        }
        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var existingCommand = _repository.GetCommandById(id);

            if (existingCommand == null)
            {
                return NotFound();
            }

            _maper.Map(commandUpdateDto, existingCommand);

            _repository.UpdateCommand(existingCommand);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var existingCommand = _repository.GetCommandById(id);

            if (existingCommand == null)
            {
                return NotFound();
            }

            var commandToPath = _maper.Map<CommandUpdateDto>(existingCommand);
            patchDoc.ApplyTo(commandToPath, ModelState);

            if (!TryValidateModel(commandToPath))
            {
                return ValidationProblem(ModelState);
            }
            _maper.Map(commandToPath, existingCommand);

            _repository.UpdateCommand(existingCommand);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var existingCommand = _repository.GetCommandById(id);

            if (existingCommand == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(existingCommand);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
