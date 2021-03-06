using System;
using System.Collections.Generic;

#nullable disable

namespace StatisticsRepository
{
    public partial class PokemonCard
    {
        public PokemonCard()
        {
            CardCollections = new HashSet<CardCollection>();
            Posts = new HashSet<Post>();
        }

        public int PokemonId { get; set; }
        public int RarityId { get; set; }
        public string SpriteLink { get; set; }
        public string SpriteLinkShiny { get; set; }
        public string PokemonName { get; set; }

        public virtual RarityType Rarity { get; set; }
        public virtual ICollection<CardCollection> CardCollections { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
