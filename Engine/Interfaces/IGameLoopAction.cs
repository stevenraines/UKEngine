namespace RLEngine
{

    public interface IGameLoopAction
    {

        int ExecuteAt { get; set; }

        IGameObject owner { get; set; }

        void Execute();

    }

}