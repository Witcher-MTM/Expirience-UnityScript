using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Expirience
{
    public struct Json
    {

        public static void SaveExp(Expirience exp)
        {
            File.WriteAllText(exp.FileName, JsonSerializer.Serialize(exp));
        }
    }
}
