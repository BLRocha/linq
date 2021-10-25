using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using linq.Entities.Enum;

namespace linq.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        public double Prince { get; set; }
        public Tier Tier { get; set; }

        public override string ToString()
        {
            return "\nID: " + Id + ", " +
                "NAME: " + Name + ", " +
                "DEPARTMENT: " + Department.Name + ", " +
                "PRINCE: " + Prince.ToString("F2", CultureInfo.InvariantCulture) + ", " +
                "TIER: " + Tier + "\n";
        }
    }
}
