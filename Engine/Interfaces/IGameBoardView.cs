using System;
using System.Collections.Generic;
using RLEngine.Enumerations;


namespace RLEngine
{

    public interface IGameBoardView
    {

        IList<IGameBoardPosition> Positions { get; }


    }

}