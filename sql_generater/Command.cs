using System.Collections.Generic;

namespace sql_generater
{
    class Command
    {
        public string Table { get; set; }
        public IList<Condition> Conditions { get; set; }
    }
}
