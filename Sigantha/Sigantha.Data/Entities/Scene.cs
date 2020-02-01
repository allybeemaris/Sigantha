using System;
using System.Collections.Generic;

namespace Sigantha.Data.Entities
{
    public class Scene
    {
        public Guid Id { get; set; }
        public Guid TimelineId { get; set; }
        public Guid? EventId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Timeline Timeline { get; set; }
        public Event Event { get; set; }
        public ICollection<SceneLegacy> SceneLegacies { get; set; }
    }
}
