using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNumberIncrements.Data
{
    public class Patch
    {
        public required string Name { get; set; }
        public required string Directory { get; set; }
        public required string Ordinal { get; set; }
        public required string[] Scripts { get; set; }
    }
}
