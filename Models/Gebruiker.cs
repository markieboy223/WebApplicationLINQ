namespace WebApplication1.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Leeftijd { get; set; }
        public string Woonplaats { get; set; }
        public int OpleidingId { get; set; }
        public Opleiding Opleiding { get; set; }
    }
}
