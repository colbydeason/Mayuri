using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class Log
    {
        public int Duration { get; }
        public Source Source { get; }
        public Log(int duration, Source source)
        {
            Duration = duration;
            Source = source;
        }
    }
}
