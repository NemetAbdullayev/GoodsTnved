using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Tables
{
    public class Goods
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? Defis { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Goods> Children { get; set; }

    }
 
    
}
