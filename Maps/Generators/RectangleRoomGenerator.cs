using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Entities;

namespace UKEngine.Maps.Generators
{
    public static class RectangleRoomGenerator
    {

        public static List<(int x, int y, GameObject gameObject)> Generate(int width, int height)
        {
            var roomData = new List<(int x, int y, GameObject gameObject)>();
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var isWall = x == 0 || y == 0 || x == width - 1 || y == height - 1;
                    roomData.Add((x, y, new GameObject(isWall ? Types.EntityType.Wall : Types.EntityType.Floor)));

                }

            }

            return roomData;

        }

    }
}