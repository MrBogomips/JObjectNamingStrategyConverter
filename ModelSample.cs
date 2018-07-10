using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace jobject_poc {
    public class ModelSample {
        public string FirstName { get; set; }
        public int AncientAge { get; set; }

        public JObject CustomData { get; set; }
    }
}