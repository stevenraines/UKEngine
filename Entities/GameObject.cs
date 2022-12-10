using System;
using System.Collections.Generic;
using System.Linq;
using UKEngine.Maps;
using UKEngine.Types;

namespace UKEngine.Entities
{

    public class GameObject
    {
        // the unique id of the entity
        public Guid Id { get; } = Guid.NewGuid();

        // the type of entity this is
        public EntityType EntityType { get; set; } = 0;
        public bool Blocking { get; set; } = true;

        public MapPosition Position { get; set; }

        public GameObject(EntityType entityType)
        {
            EntityType = entityType;
        }

        public bool Move((int x, int y) direction)
        {
            return Position.Map.MoveEntity(this, direction);

        }

    }

}