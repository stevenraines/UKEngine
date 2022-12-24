using System.Text;
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
        Player = (int)'@', //64

        [Navigable(false)]
        Monster = (int)'M', //??

        [Navigable(false)]
        Wall = 178,

        [Navigable(true)]
        OpenDoor = 47,

        [Navigable(false)]
        ClosedDoor = 43,


    }
}