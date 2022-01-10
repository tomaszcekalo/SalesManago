using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public enum DictionaryPropertyType
    {
        NUMBER,
        DATE
    }

    public class DictionaryProperty
    {
        public string Name { get; set; }
        public DictionaryPropertyType Type { get; set; }
        public string Value { get; set; }
    }
}