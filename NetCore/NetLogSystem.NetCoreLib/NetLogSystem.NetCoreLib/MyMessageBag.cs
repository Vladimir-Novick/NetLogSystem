using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetLogSystem.NetCoreLib
{
    public class MyMessageBag : ConcurrentBag<LogMessage>
    {
       
        public  void AddMessage(LogMessage message)
        {
            this.Add(message);
        }


    }
}
