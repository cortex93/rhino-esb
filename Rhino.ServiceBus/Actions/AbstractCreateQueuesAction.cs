#if NET45
using System.Messaging;
#endif
#if NETSTANDARD2_0
using Experimental.System.Messaging;
#endif
using Rhino.ServiceBus.Msmq;

namespace Rhino.ServiceBus.Actions
{
    public abstract class AbstractCreateQueuesAction : IDeploymentAction
    {
        private readonly IQueueStrategy queueStrategy;

        protected AbstractCreateQueuesAction(IQueueStrategy queueStrategy)
        {
            this.queueStrategy = queueStrategy;
        }

        public abstract void Execute(string user);

        protected void CreateQueues(QueueType mainQueueType, Endpoint mainQueueEndpoint, string user)
        {
            // will create the queues if they are not already there
            var queues = queueStrategy.InitializeQueue(mainQueueEndpoint, mainQueueType);
            foreach (var queue in queues)
            {
                GrantPermissions(queue, user);
            }
        }

        protected void GrantPermissions(MessageQueue queue, string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
#if NET45
                queue.SetPermissions(user,
                                     MessageQueueAccessRights.DeleteMessage |
                                     MessageQueueAccessRights.DeleteJournalMessage |
                                     MessageQueueAccessRights.GenericRead |
                                     MessageQueueAccessRights.GenericWrite |
                                     MessageQueueAccessRights.GetQueuePermissions |
                                     MessageQueueAccessRights.PeekMessage |
                                     MessageQueueAccessRights.ReceiveJournalMessage |
                                     MessageQueueAccessRights.ReceiveMessage |
                                     MessageQueueAccessRights.WriteMessage,
                                     AccessControlEntryType.Allow);
#endif
            }
        }
    }
}
