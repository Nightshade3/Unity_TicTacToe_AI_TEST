using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerNew : MonoBehaviour
{
    // Start is called before the first frame update
    public int GenerationSize;
    public bool IsGenProcessNeeded;
    public bool IsRandomTurn;
    //public ControlState StartingPlayerTurn;
    public static List<Board> boards = new List<Board>();
    public Text TextComponentUI_O, TextComponentUI_X, TextComponet_UI_DrawGames;
    void Start()
    {
        //IsGenProcessNeeded = true;//debugging code 
        TextComponentUI_O.text = "0";
        TextComponentUI_X.text = "0";
        TextComponet_UI_DrawGames.text = "0";
    }
    void Update()
    {
        if (IsGenProcessNeeded)
        {
            int xWins = 0, oWins = 0, drawNum = 0;
            foreach (Board item in boards = Board.Createboards(GenerationSize))
            {
                PlaySingleGame(item);
                if (item.GameWinner == Board.ControlState.PlayerXControl)
                {
                    xWins++;
                }
                else if (item.GameWinner == Board.ControlState.PlayerOControl)
                {
                    oWins++;
                }
                else
                {
                    drawNum++;
                }

            }
            UpdateUI(xWins, oWins, drawNum);
            IsGenProcessNeeded = false;
        }
    }
    void UpdateUI(int x_Wins, int o_Wins, int drawNum)
    {
        TextComponentUI_O.text = o_Wins.ToString();
        TextComponentUI_X.text = x_Wins.ToString();
        TextComponet_UI_DrawGames.text = drawNum.ToString();
    }
    void PlaySingleGame(Board gameBoard)//plays a single game
    {
        gameBoard.SwitchPlayerTurn(IsRandomTurn);
        for (; gameBoard.TurnCount < 9; gameBoard.TurnCount++)
        {   //start
            //Debug.Log("starting turn: " + gameBoard.TurnCount + " for player: " + gameBoard.CurrentPlayerTurn);
            if (gameBoard.IsGameComplete)
            {
                Debug.Log("Gamedone ending early");
                break;
            }
            //middle
            //gameBoard.BoardGrid[GetAiTurn(gameBoard)] = gameBoard.CurrentPlayerTurn;
            MiniMax_AI.GetAiMoveByMiniMax(gameBoard,gameBoard.CurrentPlayerTurn);
            //end            
            if (gameBoard.HasGameBeenWon(Board.ControlState.PlayerXControl))
            {
                gameBoard.IsGameComplete = true;
                gameBoard.GameWinner = Board.ControlState.PlayerXControl;
                //Debug.Log("Player X has won");
                break;
            }
            if (gameBoard.HasGameBeenWon(Board.ControlState.PlayerOControl))
            {
                gameBoard.IsGameComplete = true;
                gameBoard.GameWinner = Board.ControlState.PlayerOControl;
                //Debug.Log("Player O has won");
                break;
            }
            //Debug.Log("ending turn");
            gameBoard.SwitchPlayerTurn();

        }
    }

    public static int GetAiTurn(Board boardGrid)
    {
        int randomSpace;
        int iterations = 0;
        int maxIterations = 1000; // Set your desired maximum number of iterations

        do
        {
            randomSpace = Random.Range(0, 9);
            iterations++;

            // Check if the maximum number of iterations has been reached
            if (iterations >= maxIterations)
            {
                //Debug.LogError("Max iterations reached. Exiting the loop.");
                break; // Exit the loop
            }
        } while (boardGrid.BoardGrid[randomSpace] != Board.ControlState.NoControl);
        return randomSpace;
    }
}
