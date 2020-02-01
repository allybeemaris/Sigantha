using System;
using System.Collections.Generic;

namespace Sigantha.Data.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid? EraId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Era Era { get; set; }
        public virtual ICollection<EventLegacy> EventLegacies { get; set; }
    }
}
