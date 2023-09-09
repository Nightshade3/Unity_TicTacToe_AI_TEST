using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    //public Button[] VisualGrid
    public bool IsAI;
    public enum WhoPlaysFirst
    {
        Random,
        PlayerX,
        PlayerO,
    }
    public enum CurrentPlayer
    {
        PlayerX,
        PlayerO
    }
    public int genSize;
    public static List<Board> boards = new List<Board>();

    void Start()
    {
        //GridPos1= GetComponent<Button>();
        boards = BoardManager.Createboards(genSize);
        
    }


    // Update is called once per frame
    void Update()
    {


    }
    public void ResetBoard(int boardId)
    {

    }
    public void ResetAllBoards()
    {

    }
    public void PlayGame()
    {
        for (int i = 0; i <= 8; i++)
        {

        }
    }
    public static int GetAiTurn(ControlState[] boardGrid,CurrentPlayer currentPlayer)
    {
        int RandomSpace;
        //this will be a thrughline for the neat algorithm for now we will return a random valid space
        do 
        {
            RandomSpace = Random.Range(0, 8);
        } while (boardGrid[RandomSpace] == ControlState.NoControl);
        return RandomSpace;
    }
}
public enum ControlState
{
    NoControl,
    PlayerXControl,
    PlayerOControl,
}
public class Board //: MonoBehaviour
{

    public int BoardId { get; private set; }
    //public Button[] BoardGrid = new Button[9];
    public ControlState[] BoardGrid = new ControlState[9];
    public bool IsGameComplete { get; set; }
    //public bool IsVisual { get; set; }
    public Board(int boardId)
    {
        BoardId = boardId;
    }
}
public static class BoardManager
{
    public static List<Board> Createboards(int genSize)
    {

        List<Board> toReturn = new List<Board>();
        for (int i = 0; i < genSize; i++)
        {          
            Board board = new Board(i);
            board.IsGameComplete= false;
            toReturn.Add(board);
            Debug.Log("Finsihed board ID: " + i);
        }
        return toReturn;
    }
    public static void PlayerInput(int BoardID, bool IsPlayerX, int Space)
    {
        if (IsPlayerX)
        {
            Gamecontroller.boards[BoardID].BoardGrid[Space] = ControlState.PlayerXControl;//sets the specified board space to belong to player x

        }
        else if (!IsPlayerX)
        {
            Gamecontroller.boards[BoardID].BoardGrid[Space] = ControlState.PlayerOControl;//sets the specified board space to belong to player o

        }
    }

}
