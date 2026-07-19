using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOS.Utilities.Enum
{
    public enum PasswordVerificationStatus
    {
        Failed = 0,
        Success = 1,
        SuccessRehashNeeded = 2
    }
}
