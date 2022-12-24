using RLEngine.Attributes;

namespace RLEngine.Enumerations
{
    public enum GameObjectType

    {
        [Navigable(true)]
        None = -1,

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