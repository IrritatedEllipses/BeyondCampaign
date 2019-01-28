using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string School { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public SpellComponents Components { get; set; }
        public string Duraction { get; set; }
        public string Description { get; set; }
    }
}
