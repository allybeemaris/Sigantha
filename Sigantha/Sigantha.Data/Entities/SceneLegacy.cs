using System;

namespace Sigantha.Data.Entities
{
    public class SceneLegacy
    {
        public Guid Id { get; set; }
        public Guid SceneId { get; set; }
        public Guid LegacyId { get; set; }

        public Scene Scene { get; set; }
        public Legacy Legacy { get; set; }
    }
}
