using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Helpers
{
    public class TimeHelper
    {
        public string toTimeSpan(DateTime _dtDate)
        {
            TimeSpan span = (_dtDate.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            return span.TotalSeconds.ToString();
        }
    }
}
