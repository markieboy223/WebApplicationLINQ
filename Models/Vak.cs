namespace WebApplication1.Models
{
    public class Vak
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cijfer { get; set; }
        public List<Student> studenten { get; set; }
        public int OpleidingId { get; set; }
        public Opleiding opleiding { get; set; }
    }
}
