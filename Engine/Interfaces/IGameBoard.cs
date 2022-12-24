using System.Collections.Generic;
using RLEngine.Enumerations;

namespace RLEngine
{

    public interface IGameBoard
    {

        int Seed { get; }

        IGameLoop GameLoop { get; }
        IList<IGameObject> GameObjects { get; }
        bool AddGameObject(IGameObject gameObject);
        bool AddGameObject(IGameObject gameObject, int x, int y, int z);
        bool AddGameObject(GameObjectType type, int x, int y, int z);
        bool AddGameObjects(int x, int y, IList<(int x, int y, int z, GameObjectType gameObjectType)> gameObjectPositions);


        bool SetGameObjectPosition(IGameObject gameObject, int x, int y, int z);
        IGameBoardPosition GetGameBoardPosition(int x, int y, int z);
        bool MoveGameObject(IGameObject gameObject, int x, int y, int z);
    }

}