using System;
using RLEngine.Enumerations;

namespace RLEngine
{

    public interface IScheduledAction
    {
        Guid Id { get; }
        long ExecuteAt { get; set; }
        Guid OwnerId { get; }
        IAction Action { get; }

    }

}