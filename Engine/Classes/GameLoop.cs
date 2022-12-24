using RLEngine.Enumerations;

namespace RLEngine
{

    public class GameLoop : IGameLoop
    {
        public GameLoopType Type { get; }

        public GameLoop(GameLoopType type)
        {
            Type = type;
        }
    }

}