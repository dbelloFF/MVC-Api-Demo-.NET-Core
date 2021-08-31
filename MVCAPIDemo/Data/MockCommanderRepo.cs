using MVCAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIDemo.Data
{
    public class MockCommanderRepo : ICommanderRepository
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>
            {
                new Command()
                {
                    Id = 1,
                    HowTo = "Build an egg",
                    Line = "Boil water",
                    Platform = "Windows"
                },
                new Command()
                {
                    Id = 2,
                    HowTo = "Build an egg",
                    Line = "Boil water",
                    Platform = "Windows"
                },
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command()
            {
                Id = 3,
                HowTo = "Build an egg",
                Line = "Boil water",
                Platform = "Windows"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
