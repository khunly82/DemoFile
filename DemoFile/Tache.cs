using System.Net;

namespace DemoFile
{
    public class Tache
    {
        public Tache(string name, string description, DateTime deadLine)
        {
            Name = name;
            Description = description;
            DeadLine = deadLine;
        }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DeadLine { get; set; }
        public DateTime? StartDate { get; set; }
        public string? UserName { get; set; } = null!;

        public Status Status { get; set; } = Status.Created;
    }

    public enum Status
    {
        Created, InProgress, Finished
    }
}
