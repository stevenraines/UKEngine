using RLEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using RLEngine.Enumerations;

namespace RLEngine
{

    public interface IGameLoop
    {
        GameLoopType Type { get; }
        long GameTick { get; set; }
        IList<IScheduledAction> ScheduledActions { get; }

        void ScheduleAction(IScheduledAction scheduledAction);
        Task<long> ExecuteActions();
    }

}