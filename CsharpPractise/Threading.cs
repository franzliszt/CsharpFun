using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpPractise {
    class Threading {
        internal static AppDomain GetAppDomain() {
            return Thread.GetDomain();
        }
    }
}
