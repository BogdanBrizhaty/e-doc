using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Common.Constants
{
    public static class DataConstants
    {
        public const string NoDiseaseCode = "NOCODE";

        public static class Defaults
        {
            public const string DocAvatarPath = @"/Content/img/default-male-doctor-avatar.png";
            public const string DocAvatarThumbnailPath = @"/Content/img/default-male-doctor-avatar.png";
            public const string PatientAvatarPath = @"/Content/img/default-male-patient-avatar.png";
            public const string PatientAvatarThumbnailPath = @"/Content/img/default-male-patient-avatar.png";
        }
    }
}
