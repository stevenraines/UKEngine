using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Entities;

namespace UKEngine.Maps
{
    public class MapEntity : Position
    {

        public int Layer { get; protected set; }
        public GameObject Entity = null;
        public Map Map { get; }

        //construct the postion
        public MapEntity(int layer, int x, int y, GameObject entity, MapEntity mapEntity)
        {
            Layer = layer;
            X = x;
            Y = y;
            Entity = entity;
            Entity.MapEntity = mapEntity;

        }

    }
}