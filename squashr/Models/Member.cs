using ProtoBuf;

namespace squashr.Models
{
    [ProtoContract]
    public class Member
    {
        [ProtoMember(1)]
        public string Ip { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
