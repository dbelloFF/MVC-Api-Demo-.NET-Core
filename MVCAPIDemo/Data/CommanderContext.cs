using Microsoft.EntityFrameworkCore;
using MVCAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIDemo.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base (opt)
        {

        }
        /// <summary>
        /// Represents the command objects as a DbSet
        /// </summary>
        public DbSet<Command> Commands { get; set; }
    }
}
