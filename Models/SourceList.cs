using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class SourceList
    {
        private List<Source> _sourceList;
        public SourceList()
        {
            _sourceList = new List<Source>();
        }
        public void AddSource(Source source)
        {
            _sourceList.Add(source);
        }
    }
}
