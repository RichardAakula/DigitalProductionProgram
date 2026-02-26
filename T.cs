using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalProductionProgram.ControlsManagement;

namespace DigitalProductionProgram
{
    public static class T
    {
        public static string Get(string key)
            => LanguageManager.GetString(key);
    }


}
