using System.ComponentModel.DataAnnotations;

namespace Futurama.Shared
{
    public class ActorCreateUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
