using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNumberIncrements.Data
{
    public class ProjectDetails
    {
        public required string Version { get; set; }
        public required Patch Patch { get; set; }
    }
}
