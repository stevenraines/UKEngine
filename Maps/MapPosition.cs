using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Entities;

namespace UKEngine.Maps
{
    public class MapPosition
    {

        public int Layer { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }
        public GameObject Entity = null;

        public Map Map { get; }

        //construct the postion
        public MapPosition(int layer, int x, int y, GameObject entity, Map map)
        {
            Layer = layer;
            X = x;
            Y = y;
            Entity = entity;
            Entity.Position = this;
            Map = map;
        }

    }
}