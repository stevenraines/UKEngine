using UKEngine.Attributes;

namespace UKEngine.Types
{
    public enum EntityType

    {
        [Navigable(true)]
        Floor = 249,

        [Navigable(false)]
        Player = 64,

        [Navigable(false)]
        Wall = 178,

        [Navigable(true)]
        OpenDoor = 47,

        [Navigable(false)]
        ClosedDoor = 43,


    }
}