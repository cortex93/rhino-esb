#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using System.Threading;

namespace Rhino.ServiceBus.Msmq
{
    public class QueueState
    {
        public MessageQueue Queue;
        public ManualResetEvent WaitHandle;
    }
}