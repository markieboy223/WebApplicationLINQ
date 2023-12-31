﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Opleiding)
                .WithMany(o => o.studenten)
                .HasForeignKey(s => s.OpleidingId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WebApplication1.Models.Student> Student { get; set; } = default!;
        public DbSet<WebApplication1.Models.Docent> Docent { get; set; } = default!;
        public DbSet<WebApplication1.Models.Opleiding> Opleidingen { get; set; } = default!;
        public DbSet<WebApplication1.Models.Vak> Vakken { get; set; } = default!;

    }
}
