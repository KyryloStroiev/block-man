using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
    public class EntityData
    {
        [JsonProperty("ec")] public List<EntitySnapshot> MetaEntitySnapshots;
    }
}