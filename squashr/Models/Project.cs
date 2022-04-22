using System.Collections.Generic;
using ProtoBuf;

namespace squashr.Models
{
    [ProtoContract]
    public class Project
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int HostId { get; set; }
        [ProtoMember(4)]
        public List<Member> Members { get; set; }
    }
}
