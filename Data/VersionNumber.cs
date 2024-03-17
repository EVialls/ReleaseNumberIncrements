using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNumberIncrements.Data
{
    public class VersionNumber
    {
        public int Major;
        public int Minor;
        public int Patch;

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
