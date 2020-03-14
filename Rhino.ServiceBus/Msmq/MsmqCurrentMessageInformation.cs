using System.Collections.Specialized;
#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Impl;

namespace Rhino.ServiceBus.Msmq
{
    public class MsmqCurrentMessageInformation : CurrentMessageInformation
    {
        public OpenedQueue Queue { get; set; }
        public Message MsmqMessage { get; set; }
        public NameValueCollection Headers { get; set; }

        public MessageQueueTransactionType TransactionType { get; set; }
    }
}