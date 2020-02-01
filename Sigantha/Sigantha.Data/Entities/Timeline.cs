using System;

namespace Sigantha.Data.Entities
{
    public class Timeline
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
