using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Entities;

namespace UKEngine.Maps
{
    public class Map
    {

        private List<MapEntity> Entities = new List<MapEntity>();

        public Map()
        {
        }

        public MapEntity GetPosition(int layer, int x, int y)
        {
            return Entities.Where(c => c.Layer == layer && c.X == x && c.Y == y).FirstOrDefault();
        }

        public List<MapEntity> GetLayer(int layer)
        {
            return Entities.Where(c => c.Layer == layer).ToList();
        }

        public void AddEntity(int layer, int x, int y, GameObject gameObject)
        {
            var entity = Entities.Where(e => e.Entity.Id == gameObject.Id).ToList();
            entity.ForEach(e => Entities.Remove(e));
            var newEntity = new MapEntity(layer, x, y, gameObject, this);
            Entities.Add(newEntity);
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