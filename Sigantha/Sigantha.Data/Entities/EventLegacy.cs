using System;
using System.Collections.Generic;
using System.Text;

namespace Sigantha.Data.Entities
{
    public class EventLegacy
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid LegacyId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Legacy Legacy { get; set; }
    }
}
