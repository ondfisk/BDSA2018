using System.ComponentModel.DataAnnotations;

namespace BDSA2018.Lecture04
{
    public partial class Character
    {
        public int Id { get; set; }
        public int? ActorId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Planet { get; set; }
        public Actor Actor { get; set; }
    }
}
