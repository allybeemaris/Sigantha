using System;
using System.Collections.Generic;

namespace Sigantha.Data.Entities
{
    public class Timeline
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<Legacy> Legacies { get; set; }
        public virtual ICollection<Era> Eras { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Scene> Scenes { get; set; }
    }
}
