﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Opleiding
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> studenten {  get; set; }
        public List<Vak> Vakken { get; set; }
    }
}
