using Microsoft.AspNetCore.Http;
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

        //OrderBy age
        [HttpGet("OrderByAgeDesc")]
        public async Task<IEnumerable<Student>> OrderByAgeDesc()
        {
            var students = await _context.Student.OrderByDescending(s => s.Leeftijd).ToListAsync();
            return students;
        }

        [HttpGet("NaamEnLeeftijdStudent")]
        public async Task<IEnumerable<object>> NaamEnLeeftijdStudent()
        {
            var students = await _context.Student.Select(s => new { Naam = s.Name, Leeftijd = s.Leeftijd }).ToListAsync();
            return students;
        }

        [HttpGet("VakkenMetCijferHogerDan8")]
        public async Task<IEnumerable<Vak>> VakkenMetCijferHogerDan8()
        {
            var vakken = await _context.Vakken.Where(v => v.Cijfer > 8).ToListAsync();
            return vakken;
        }

        [HttpGet("DocentDieLesGeeft")]
        public async Task<IEnumerable<Docent>> DocentDieLesGeeft()
        {
            var docenten = await _context.Docent.Where(d => d.Eigenschap.Equals("Teaching")).ToListAsync();
            return docenten;
        }

        [HttpGet("StudentenMetElectricalEngineering")]
        public async Task<IEnumerable<object>> StudentenMetElectricalEngineering()
        {
            var student = await _context.Student
                .Where(s => s.Opleiding.Name == "Electrical Engineering")
                .ToListAsync();
            return student;
        }

        [HttpGet("GemiddeldCijferPerStudent")]
        public async Task<IEnumerable<object>> GemiddeldCijferPerStudent()
        {
            var gemiddelde = await _context.Student
                .GroupBy(s => new { s.Name, s.OpleidingId})
                .Select(g => new
                {
                    Naam = g.Key.Name,
                    OpleidingId = g.Key.OpleidingId,
                    GemiddeldCijfer = g.Join(_context.Vakken, s => s.OpleidingId, v => v.OpleidingId, (s, v) => v.Cijfer).Average()
                })
                .ToListAsync();
            return gemiddelde;
        }

        [HttpGet("vakkenBusinessOpleiding")]
        public async Task<IEnumerable<Vak>> vakkenBusinessOpleiding()
        {
            var vakken = await _context.Vakken.Where(v => v.OpleidingId == 3).ToListAsync();
            return vakken;
        }

        [HttpGet("DocentenJongerDan40")]
        public async Task<IEnumerable<object>> DocentenJongerDan40()
        {
            var docenten = await _context.Docent
                .Select(s => new {Naam = s.Name, Leeftijd = s.Leeftijd})
                .Where(d => d.Leeftijd < 40)
                .ToListAsync();
            return docenten;
        }
        [HttpGet("StudentOuderDan20Cityville")]
        public async Task<IEnumerable<string>> StudentOuderDan20Cityville()
        {
            var studenten = await _context.Student.Where(s => s.Leeftijd > 20 && s.Woonplaats.Equals("Cityville")).Select(v => v.Name).ToListAsync();
            return studenten;
        }

        [HttpGet("vakkenCijfer")]
        public async Task<IEnumerable<Vak>> vakkenCijfer()
        {
            var vakken = await _context.Vakken.Where(v => v.Cijfer > 7.5 && v.Cijfer < 9).ToListAsync();
            return vakken;
        }

        [HttpGet("DocentResearch")]
        public async Task<IEnumerable<string>> DocentResearch()
        {
            var docenten = await _context.Docent.Where(d => d.Eigenschap.Equals("Research")).Select(n => n.Name).ToListAsync();
            return docenten;
        }
    }
}
