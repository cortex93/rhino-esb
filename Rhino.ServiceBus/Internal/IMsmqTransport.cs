using System;
#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Msmq;

namespace Rhino.ServiceBus.Internal
{
    public interface IMsmqTransport : ITransport
    {
        void RaiseAdministrativeMessageProcessingCompleted(CurrentMessageInformation information, Exception ex);

        bool RaiseAdministrativeMessageArrived(CurrentMessageInformation information);

        void ReceiveMessageInTransaction(OpenedQueue queue, 
            string messageId, 
            Func<CurrentMessageInformation, bool> messageArrived,
            Action<CurrentMessageInformation, Exception> messageProcessingCompleted, 
			Action<CurrentMessageInformation> beforeMessageTransactionCommit,
            Action<CurrentMessageInformation> beforeMessageTransactionRollback);

        void RaiseMessageSerializationException(OpenedQueue queue, Message msg, string errorMessage);
        OpenedQueue CreateQueue();
    }
}