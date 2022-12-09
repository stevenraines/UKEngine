using System;
using System.Collections.Generic;
using System.Linq;

namespace UKEngine.Maps
{
    public class MapPosition
    {

        public int Layer { get; }
        public int X { get; }
        public int Y { get; }


        public bool Navigable { get; protected set; }

        public MapPosition(int layer, int x, int y)
        {
            Layer = layer;
            X = x;
            Y = y;
        }
        public MapPosition(int layer, int x, int y, bool navigable) : this(layer, x, y)
        {
            Navigable = navigable;
        }
    }
}