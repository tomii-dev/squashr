using ProtoBuf;

namespace squashr.Models
{
    [ProtoContract]
    public class Bug
    {
        public enum BugSeverity
        {
            ToDo, Urgent, Immediate
        }
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Notes { get; set; }
        [ProtoMember(4)]
        public int Status { get; set; }
        [ProtoMember(5)]
        public BugSeverity Severity { get; set; }
    }
}
