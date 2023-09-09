using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class Board //: MonoBehaviour
    {
        public int BoardId { get; private set; }
        public ControlState CurrentPlayerTurn { get; set; }
        public ControlState[] BoardGrid = new ControlState[9];
        public bool IsGameComplete { get; set; }
        public ControlState GameWinner { get; set; }
        public int TurnCount { get; set; }
        //public bool IsVisual { get; set; }
        public Board(int boardId)
        {
            BoardId = boardId;
        }
    public enum ControlState
    {
        NoControl,
        PlayerXControl,
        PlayerOControl,
    }
    public bool HasGameBeenWon(ControlState player)
    {
        return HasGameBeenWon(player, BoardGrid);
    }
    public bool HasGameBeenWon(ControlState player, ControlState[] boardGrid)//when given a board it will determine if said board has achived victory
        {
            //cant think of a better way to check all this its a lot more ifs then i would like but oh well
            for (int i = 0; i < 3; i++)
            {
                if (boardGrid[i * 3] == player && boardGrid[(i * 3) + 1] == player && boardGrid[(i * 3) + 2] == player)
                {
                    return true;
                }
                if (boardGrid[i] == player && boardGrid[(i + 3)] == player && boardGrid[(i + 6)] == player)
                {
                    return true;
                }
            }
            if (boardGrid[1] == player && boardGrid[4] == player && boardGrid[8] == player)
            {
                return true;
            }
            if (boardGrid[3] == player && boardGrid[4] == player && boardGrid[6] == player)
            {
                return true;
            }
            return false;//no one has won yet
        }
        public void SwitchPlayerTurn(bool random = false, ControlState? manualPlayer = null)//switchs the players turn inverting it if already selected and allowing us to manaully select turn or choose random
        {
            if (manualPlayer != null)
            {
                //Debug.Log("setting manualplayer");
                CurrentPlayerTurn = manualPlayer.Value;
                return;
            }
            else if (random)
            {
                //Debug.Log("setting random player");
                CurrentPlayerTurn = UnityEngine.Random.Range(0, 2) == 0 ? ControlState.PlayerXControl : ControlState.PlayerOControl;
                //Debug.Log(CurrentPlayerTurn);
                return;
            }
            if (CurrentPlayerTurn == ControlState.PlayerXControl)
            {
                CurrentPlayerTurn = ControlState.PlayerOControl;
            }
            else
            {
                CurrentPlayerTurn = ControlState.PlayerXControl;
            }
        }
    public static List<Board> Createboards(int genSize)
    {
        List<Board> boardsToReturn = new List<Board>();
        for (int i = 0; i < genSize; i++)
        {
            Board board = new Board(i)
            {
                IsGameComplete = false,
                TurnCount = 0
            };
            boardsToReturn.Add(board);
           // Debug.Log("Finsihed board ID: " + i);
        }
        return boardsToReturn;
    }

}
public static class Holder
{
    
}
    

