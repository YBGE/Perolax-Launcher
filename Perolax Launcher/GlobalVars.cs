using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perolax_Launcher
{
    public static class GlobalVars //Init information
    {
        #region Project_Perolax
        //Variables that are initialized upon loading
        public static string perolax_BuildVersion = "BV N/A";
        public static string perolax_ReleaseDate = "RD N/A";
        public static string perolax_TagOfUpdate = "TOU N/A";
        #endregion

        #region Perolax_Launcher
        //Readonly Launcher Version (Gets changed manually)
        public static readonly string launcher_BuildVersion = "1B-D03M08Y23-PL";
        #endregion
    }
}
