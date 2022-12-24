using System;
using RLEngine.Enumerations;

namespace RLEngine
{

    public class ScheduledAction : IScheduledAction
    {
        public Guid Id { get; } = Guid.NewGuid();
        public long ExecuteAt { get; set; }
        public Guid OwnerId { get; }
        public IAction Action { get; }

        public ScheduledAction(Guid ownerId, IAction action)
        {
            OwnerId = ownerId;
            Action = action;
        }

    }

}