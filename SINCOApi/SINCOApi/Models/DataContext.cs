using Microsoft.EntityFrameworkCore;
using SINCOApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SINCOApi.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Profesor> profesores { get; set; }
    }
}
