#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;

namespace Rhino.ServiceBus.Msmq
{
    public class MsmqOnewayBus : IOnewayBus
    {
        private readonly MessageOwnersSelector messageOwners;
        private readonly IMessageBuilder<Message> messageBuilder;

        public MsmqOnewayBus(MessageOwner[] messageOwners, IMessageBuilder<Message> messageBuilder)
        {
            this.messageOwners = new MessageOwnersSelector(messageOwners, new EndpointRouter());
            this.messageBuilder = messageBuilder;
        }

        public void Send(params object[] msgs)
        {
            var endpoint = messageOwners.GetEndpointForMessageBatch(msgs);
            var messageInformation = new OutgoingMessageInformation
            {
                Destination = endpoint,
                Messages = msgs,
            };
            using(var queue = endpoint.InitalizeQueue())
            {
                var message = messageBuilder.BuildFromMessageBatch(messageInformation);
                queue.SendInSingleTransaction(message);
            }
        }
    }
}