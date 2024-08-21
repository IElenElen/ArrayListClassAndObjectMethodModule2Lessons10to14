using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListClassAndObjectMethodModule2Lessons10to14
{
    public class Poem
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? LiteraryPeriod { get; set; }
        public string? Content { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Author} ({LiteraryPeriod})";
        }
    }
}
