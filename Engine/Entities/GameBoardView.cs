using System;
using System.Collections.Generic;
using System.Linq;
using RLEngine.Enumerations;


namespace RLEngine
{

    public class GameBoardView : IGameBoardView
    {

        public IList<IGameBoardPosition> Positions { get; } = new List<IGameBoardPosition>();


        public GameBoardView(IGameBoard gameBoard, int startX, int startY, int widthX, int widthY, int z)
        {
            for (var xPos = startX; xPos < widthX; xPos++)
            {
                for (var yPos = startY; yPos < widthY; yPos++)
                {
                    Positions.Add(gameBoard.GetGameBoardPosition(xPos, yPos, z));
                }
            }

        }

    }

}