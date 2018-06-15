using System;
using System.Collections.Generic;
using System.Text;

namespace LinqManhattan.JSON_Classes
{
    class Feature
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }
}
