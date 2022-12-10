using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Entities;

namespace UKEngine.Maps
{
    public class Map
    {

        private List<MapPosition> Positions = new List<MapPosition>();

        public Map()
        {
        }

        public MapPosition GetPosition(int layer, int x, int y)
        {
            return Positions.Where(c => c.Layer == layer && c.X == x && c.Y == y).FirstOrDefault();
        }

        public List<MapPosition> GetLayer(int layer)
        {
            return Positions.Where(c => c.Layer == layer).ToList();
        }

        public void AddEntity(int layer, int x, int y, GameObject gameObject)
        {
            var positionsWithGameObject = Positions.Where(e => e.Entity.Id == gameObject.Id).ToList();
            positionsWithGameObject.ForEach(e => Positions.Remove(e));
            var position = new MapPosition(layer, x, y, gameObject, this);
            Positions.Add(position);
        }

        public bool MoveEntity(GameObject gameObject, (int x, int y) direction)
        {

            var positionWithGameObject = Positions.Where(e => e.Entity.Id == gameObject.Id).FirstOrDefault();
            if (positionWithGameObject == null) return false;
            positionWithGameObject.X += direction.x;
            positionWithGameObject.Y += direction.y;
            return true;


        }


        public void AssignTerrain((int x, int y) startingPoint, List<(int X, int Y, GameObject gameObject)> roomData)
        {
            foreach (var pos in roomData)
            {
                //see if gameobjectt exists elsewhere, remove it
                AddEntity(0, pos.X + startingPoint.x, pos.Y + startingPoint.y, pos.gameObject);
            }
        }




    }
}