using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLogger.AppService.Contract
{
    public enum Status : byte
    {
        Accepted = 1,
        Pending = 2,
        Deleted = 3
    }
}