#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using layer2.Models;

namespace layer2.Data
{
    public class layer2Context : DbContext
    {
        public layer2Context (DbContextOptions<layer2Context> options)
            : base(options)
        {
        }

        public DbSet<layer2.Models.User> User { get; set; }
    }
}
