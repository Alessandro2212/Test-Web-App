using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities.TypeAndEnums
{
    public static class Enum
    {
        public enum PoolStateEnum
        {
            Close,
            Open,
            InProgress
        }

        public enum UserStateEnum
        {
            Online,
            Offline
        }
    }
}
