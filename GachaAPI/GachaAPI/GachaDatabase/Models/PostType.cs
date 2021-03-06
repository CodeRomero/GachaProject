using System;
using System.Collections.Generic;

#nullable disable

namespace GachaDatabase.Models
{
    public partial class PostType
    {
        public PostType()
        {
            DisplayBoards = new HashSet<DisplayBoard>();
        }

        public int PostType1 { get; set; }
        public string PostCategory { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DisplayBoard> DisplayBoards { get; set; }
    }
}
