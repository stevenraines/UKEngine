using System;
using RLEngine;

namespace RLEngine
{

    public class MoveAction : IAction
    {
        IGameObject Owner { get; }
        int X { get; }
        int Y { get; }
        int Z { get; }

        public MoveAction(IGameObject owner, int x, int y, int z)
        {
            Owner = owner;
            X = x;
            Y = y;
            Z = z;
        }

        public bool Execute()
        {
            return Owner.Move(X, Y, Z);
        }

    }

}