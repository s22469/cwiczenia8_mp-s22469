using Recepty.Dtos;
using Recepty.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recepty.Services
{
    public class DbService
    {
        private readonly ExampleDbContext _context;

        public DbService(ExampleDbContext context)
        {
            _context = context;
        }
    }
}