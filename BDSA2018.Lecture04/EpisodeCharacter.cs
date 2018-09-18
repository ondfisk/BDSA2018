using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Lecture04
{
    public class EpisodeCharacter
    {
        public string EpisodeNumber { get; set; }

        public int CharacterId { get; set; }

        public virtual Episode Episode { get; set; }
        public virtual Character Character { get; set; }
    }
}
