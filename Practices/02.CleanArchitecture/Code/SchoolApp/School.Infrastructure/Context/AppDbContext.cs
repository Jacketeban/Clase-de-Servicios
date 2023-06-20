using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System.Collections.Generic;
using System;

namespace School.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}