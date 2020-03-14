#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Internal;

namespace Rhino.ServiceBus.Msmq.TransportActions
{
    public interface IMsmqTransportAction
    {
        void Init(IMsmqTransport transport, OpenedQueue queue);

        bool CanHandlePeekedMessage(Message message);
        bool HandlePeekedMessage(IMsmqTransport transport, OpenedQueue queue, Message message);
    }
}