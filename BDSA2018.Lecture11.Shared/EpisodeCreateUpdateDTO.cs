using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BDSA2018.Lecture11.Shared
{
    public class EpisodeCreateUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public DateTime? FirstAired { get; set; }

        public ICollection<int> CharacterIds { get; set; }
    }
}
