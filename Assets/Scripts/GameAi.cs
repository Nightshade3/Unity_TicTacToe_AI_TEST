using UnityEngine;

public class MiniMax_AI : MonoBehaviour
{
    public static int GetAiMoveByMiniMax(Board board, Board.ControlState player)// i dont think this method is needed but it provides a cleaner code experince so im keeping in the name of clean code
    {
        return PerformMiniMax(board, player);
        //return bestMove;
    }
    public static int EvaluateMove(Board board, Board.ControlState player)
    {
        bool isMaxPlayer = player == Board.ControlState.PlayerXControl;
        if (board.HasGameBeenWon(player))
        {
            if (isMaxPlayer)
            {
                return 1;
            }
            if (isMaxPlayer!)
            {
                return -1;
            }
        }
        if (isMaxPlayer)
        {
            return PerformMiniMax(board, player);
        }
        return 0;
    }
    public static int PerformMiniMax(Board board, Board.ControlState player)
    {
        int CurrentbestScore = (player == Board.ControlState.PlayerXControl) ? int.MinValue : int.MaxValue;
        for (int i = 0; i < board.BoardGrid.Length; i++)
        {
            if (board.BoardGrid[i] == Board.ControlState.NoControl)
            {
                board.BoardGrid[i] = player;
                int score = EvaluateMove(board, player);
                board.BoardGrid[i] = Board.ControlState.NoControl;
                if ((player == Board.ControlState.PlayerOControl && score < CurrentbestScore) ||
                    (player == Board.ControlState.PlayerXControl && score > CurrentbestScore))
                {
                    CurrentbestScore = score;
                }
                if (player == Board.ControlState.PlayerOControl && CurrentbestScore == -1 ||
                   (player == Board.ControlState.PlayerXControl && CurrentbestScore == 1))
                {
                    //Debug.Log(i);
                    return CurrentbestScore;

                }

            }
            

        }
        return CurrentbestScore;
    }
}


