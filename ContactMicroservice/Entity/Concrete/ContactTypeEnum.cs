using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum ContactTypeEnum
    {
        [Description("PHONE")]
        PHONE,
        [Description("EMAIl")]
        EMAIl,
        [Description("LOCATION")]
        LOCATION

    }
}
