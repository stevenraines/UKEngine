using System;
using System.Linq;
using System.Collections.Generic;
using RLEngine.Enumerations;


namespace RLEngine
{

    public class GameBoardPosition : IGameBoardPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public IList<IGameObject> GameObjects { get; set; } = new List<IGameObject>();


        public GameBoardPosition(int x, int y, int z, IList<IGameObject> gameObjects)
        {
            X = x;
            Y = y;
            Z = z;
            GameObjects = gameObjects;

        }

        public bool IsNavigable()
        {
            return GameObjects.All(g => g.Navigable);
        }

    }

}