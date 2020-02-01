using System;

namespace Sigantha.Data.Entities
{
    public class EraLegacy
    {
        public Guid Id { get; set; }
        public Guid EraId { get; set; }
        public Guid LegacyId { get; set; }

        public virtual Era Era { get; set; }
        public virtual Legacy Legacy { get; set; }
    }
}
