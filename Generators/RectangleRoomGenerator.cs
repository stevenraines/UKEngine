using System;
using System.Collections.Generic;
using System.Linq;
using RLEngine.Enumerations;

namespace RLEngine.Generators
{
    public static class RectangleRoomGenerator
    {

        public static List<(int x, int y, int z, GameObjectType type)> Generate(int width, int height, int depth = 0)
        {

            var roomData = new List<(int x, int y, int z, GameObjectType type)>();
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var isWall = x == 0 || y == 0 || x == width - 1 || y == height - 1;
                    roomData.Add((x, y, depth, isWall ? GameObjectType.Wall : GameObjectType.Floor));
                }
            }
            return roomData;

        }

    }
}