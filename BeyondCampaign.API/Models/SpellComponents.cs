using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondCampaign.API.Models
{
    public class SpellComponents
    {
        public int Id { get; set; }
        public bool Verbal { get; set; }
        public bool Somatic { get; set; }
        public bool Material { get; set; }
        public int? MaterialCost { get; set; }
        public string MaterialDescription { get; set; }
    }
}
