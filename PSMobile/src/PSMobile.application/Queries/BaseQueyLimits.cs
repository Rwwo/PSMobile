using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMobile.application.Queries;

public abstract class BaseQueyLimits
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
