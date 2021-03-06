﻿using System;
using System.Collections.Generic;
using Bit.ViewModel;

namespace XamApp.Implementations
{
    public class XamAppExceptionHandler : BitExceptionHandler
    {
        public override void OnExceptionReceived(Exception exp, IDictionary<string, string> properties = null)
        {
#if DEBUG

            System.Diagnostics.Debugger.Break();

#endif

            base.OnExceptionReceived(exp, properties);
        }
    }
}
