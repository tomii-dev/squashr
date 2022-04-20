using ProtoBuf;
using System.Collections.Generic;

namespace squashr.Models
{
    [ProtoContract]
    public class LocalUser
    {
        [ProtoMember(1)]
        public string Username { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
        [ProtoMember(3)]
        public string PfpPath { get; set; }
        [ProtoMember(4)]
        public List<Project> Projects { get; set; }
    }
}
