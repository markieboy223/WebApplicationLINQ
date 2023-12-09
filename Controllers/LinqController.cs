﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly WebApplication1Context _context;
        public LinqController(WebApplication1Context context) {
            _context = context;
        }

        //Query retrieve names and ages of all students
        [HttpGet("GetStudentsnamesandage")]
        public async Task<IEnumerable<Object>> GetStudentsnamesandage()
        {
            var students = await _context.Student.Select(s => new {s.Name, s.Leeftijd}).ToListAsync();
            return students;
        }

        //Filter students older than 21
        [HttpGet("GetStudentsOlderThan21")]
        public async Task<IEnumerable<Student>> GetStudentsOlderThan21()
        {
            var students =  await _context.Student.Where(s => s.Leeftijd > 21).ToListAsync();
            return students;
        }

        //Join
        [HttpGet("GetStudentAndOpleiding")]
        public async Task<IEnumerable<Object>> GetStudentAndOpleiding()
        {
            var students = await _context.Student
                .Join(_context.Opleidingen, s => s.OpleidingId, o => o.Id, (s, o) => new { s.Name, OpleidingName = o.Name })
                .ToListAsync();

            return students;
        }

        //Average
        [HttpGet("GetAverageAge")]
        public async Task<object> GetAverageAge()
        {
            var students = await _context.Student.Select(s => s.Leeftijd).AverageAsync();
            return students;
        }

        //Groupby opleiding
        [HttpGet("GroupByOpleiding")]
        public async Task<IEnumerable<object>> GroupByOpleiding()
        {
            var students = await _context.Student
                .GroupBy(s => s.OpleidingId)
                .Select(group => new
            {
                OpleidingId = group.Key,
                OpleidingNaam = group.First().Opleiding.Name,
                Studenten = group.Count(),
            })
                .ToListAsync();
            return students;
        }

    }
}
