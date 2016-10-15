using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlatPlanet.Models
{
    public class Numbers
    {
        public int Id { get; set; }
        public int Counter { get; set; }
    }

    public class NumberContext : DbContext
    {
        public NumberContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Numbers> Numbers { get; set; }
    }
}