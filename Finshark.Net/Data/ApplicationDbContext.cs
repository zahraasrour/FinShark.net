﻿using Finshark.Net.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Finshark.Net.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
