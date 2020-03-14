#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Internal;
using MessageType=Rhino.ServiceBus.Transport.MessageType;

namespace Rhino.ServiceBus.Msmq.TransportActions
{
    public class ShutDownAction : AbstractTransportAction
    {
        public override MessageType HandledType
        {
            get { return MessageType.ShutDownMessageMarker; }
        }

        public override bool HandlePeekedMessage(IMsmqTransport transport, OpenedQueue queue, Message message)
        {
            queue.TryGetMessageFromQueue(message.Id);
            return true;
        }
    }
}