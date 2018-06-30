using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common.Enums
{
    public enum RoleAccessPoint
    {
        Patient = 1,
        Doctor = 2,
        SuperUser = 4,
        Administrator = 8,
        SystemProfile = 16
    }
}
