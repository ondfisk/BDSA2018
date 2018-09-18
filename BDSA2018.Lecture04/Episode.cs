using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Lecture04
{
    public class Episode
    {
        [Key]
        [StringLength(10)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public virtual ICollection<EpisodeCharacter> EpisodeCharacters { get; set; }
    }
}
