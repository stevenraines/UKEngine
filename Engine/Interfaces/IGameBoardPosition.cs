using System;
using System.Collections.Generic;
using RLEngine.Enumerations;


namespace RLEngine
{

    public interface IGameBoardPosition
    {
        int X { get; }
        int Y { get; }
        int Z { get; }

        IList<IGameObject> GameObjects { get; }

    }

}