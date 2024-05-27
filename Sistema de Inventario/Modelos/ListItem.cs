using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ListItem
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }

        public ListItem(string displayName, string value)
        {
            DisplayName = displayName;
            Value = value;
        }
        public override string ToString()
        {
            return DisplayName; // Retorna el DisplayName al llamar a ToString()
        }
    }
}
