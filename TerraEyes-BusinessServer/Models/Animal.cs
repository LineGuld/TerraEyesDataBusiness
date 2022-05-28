namespace TerraEyes_BusinessServer.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Eui { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public bool HasOffspring { get; set; }
        public bool Hibernating { get; set; }
        public bool Shedding { get; set; }
    }
}