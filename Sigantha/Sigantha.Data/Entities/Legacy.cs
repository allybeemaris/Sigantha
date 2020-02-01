using System;

namespace Sigantha.Data.Entities
{
    public class Legacy
    {
        public Guid Id { get; set; }
        public Guid TimelineId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string SymbolPath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Timeline Timeline { get; set; }
    }
}
