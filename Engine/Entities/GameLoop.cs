
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RLEngine.Enumerations;

namespace RLEngine
{

    public class GameLoop : IGameLoop
    {
        public GameLoopType Type { get; }

        public int LoopFrequencyMS { get; set; } = 5000;

        public DateTime NextLoop { get; set; }

        public long GameTick { get; set; } = 0;

        public IList<IScheduledAction> ScheduledActions { get; } = new List<IScheduledAction>();



        public GameLoop(GameLoopType type)
        {
            Type = type;

        }

        public void ScheduleAction(IScheduledAction scheduledAction)
        {
            scheduledAction.ExecuteAt = GameTick += 1;
            ScheduledActions.Add(scheduledAction);
        }

        public async Task<long> ExecuteActions()
        {


            var executeStartTime = DateTime.UtcNow;

            var actionsToExecute = ScheduledActions.Where(x => x.ExecuteAt <= GameTick).ToList();

            var uniqueGameObjects = actionsToExecute.Select(a => a.OwnerId).Distinct();

            foreach (var gameObjectId in uniqueGameObjects)
            {
                IScheduledAction scheduledAction = actionsToExecute.Where(a => a.OwnerId == gameObjectId).FirstOrDefault();
                scheduledAction.Action.Execute();
                ScheduledActions.Remove(scheduledAction);
            }

            NextLoop = executeStartTime.AddMilliseconds(LoopFrequencyMS);

            GameTick += 1;
            return GameTick;

        }
    }

}