using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squashr.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HostId { get; set; } 
        public List<Member> Members { get; set; }
    }
}
