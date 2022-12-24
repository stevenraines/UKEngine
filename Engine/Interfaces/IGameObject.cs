using System;
using System.Collections.Generic;
using RLEngine.Enumerations;


namespace RLEngine
{

    public interface IGameObject
    {
        Guid Id { get; }
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }
        int Layer { get; set; }
        GameObjectType Type { get; }
        IGameBoard GameBoard { get; }
        IList<IGameComponent> Components { get; }

        bool Navigable { get; }

        bool Move(int x, int y, int z);

    }

}