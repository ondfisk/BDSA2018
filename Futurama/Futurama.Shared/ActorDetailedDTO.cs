using System.Collections.Generic;

namespace Futurama.Shared
{
    public class ActorDetailedDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IDictionary<int, string> Characters { get; set; }
    }
}
