using System;
using System.Collections.Generic;
using System.Linq;

namespace UKEngine.Maps
{
    public class Map
    {

        private List<MapPosition> Layers = new List<MapPosition>();

        public Map()
        {

        }

        public MapPosition GetAtPosition(int layer, int x, int y)
        {
            return Layers.Where(c => c.Layer == layer && c.X == x && c.Y == y).FirstOrDefault();
        }

        public List<MapPosition> GetLayer(int layer)
        {
            return Layers.Where(c => c.Layer == layer).ToList();
        }

        public void AssignTerrain((int x, int y) startingPoint, List<MapPosition> mapPositions)
        {
            foreach (var pos in mapPositions)
            {
                var offsetMapPosition = new MapPosition(pos.Layer, pos.X + startingPoint.x, pos.Y + startingPoint.y, pos.Navigable);

                Layers.Add(offsetMapPosition);
            }


        }

        public List<MapPosition> BuildRectangleRoom(int width, int height)
        {
            var positions = new List<MapPosition>();
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var isWall = x == 0 || y == 0 || x == width - 1 || y == height - 1;
                    var pos = new MapPosition(0, x, y, !isWall);
                    positions.Add(pos);
                }

            }

            return positions;

        }

    }
}