using System;
using System.Collections.Generic;

#nullable disable

namespace GachaDatabase.Models
{
    public partial class RarityType
    {
        public RarityType()
        {
            PokemonCards = new HashSet<PokemonCard>();
        }

        public int RarityId { get; set; }
        public string RarityCategory { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<PokemonCard> PokemonCards { get; set; }
    }
}
