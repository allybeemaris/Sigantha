using System;
using System.Collections.Generic;

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
        public virtual ICollection<EraLegacy> EraLegacies { get; set; }
        public virtual ICollection<EventLegacy> EventLegacies { get; set; }
        public virtual ICollection<SceneLegacy> SceneLegacies { get; set; }
    }
}
