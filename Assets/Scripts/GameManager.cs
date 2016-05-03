using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public Text playerOneText;
    public Text playerTwoText;
    public Text message;

    private GameObject s1;
    private GameObject s2;
    private GameObject s3;
    private GameObject s4;
    private GameObject s5;
    private GameObject s6;
    private GameObject s7;
    private GameObject s8;
    private GameObject s9;

    private int[,] lineArray = new int[9, 4];
    private int[] squareArray = new int[9];
    private int playerOneScore;
    private int playerTwoScore;
    private bool playerOneTurn;
    private int numberOfCompletedSquares;


    // Use this for initialization
    void Start()
    {
        s1 = GameObject.Find("s0");
        s2 = GameObject.Find("s1");
        s3 = GameObject.Find("s2");
        s4 = GameObject.Find("s3");
        s5 = GameObject.Find("s4");
        s6 = GameObject.Find("s5");
        s7 = GameObject.Find("s6");
        s8 = GameObject.Find("s7");
        s9 = GameObject.Find("s8");

        OnReset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called by SpeechManager when the user says the "Reset game" command
    void OnReset()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        playerOneTurn = true;
        numberOfCompletedSquares = 0;

        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
        message.text = "Player One's Turn";

        //reset lineArray to all zeros
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                lineArray[i, j] = 0;
            }
        }
        //reset squareArray to all zeros
        for (int k = 0; k < 9; k++)
        {
            squareArray[k] = 0;
        }

        //reset squares to be transparent
        SetObjectColor(s1, 0);
        SetObjectColor(s2, 1);
        SetObjectColor(s3, 2);
        SetObjectColor(s4, 3);
        SetObjectColor(s5, 4);
        SetObjectColor(s6, 5);
        SetObjectColor(s7, 6);
        SetObjectColor(s8, 7);
        SetObjectColor(s9, 8);
    }

    // update the ui score and message
    // change the completed square's color
    void UpdateGameBoard()
    {
        CheckForCompletedSquares();

        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();

        if (numberOfCompletedSquares >= 9)
        {
            if (playerOneScore > playerTwoScore)
            {
                message.text = "Player One WINS!";
            }
            else
            {
                message.text = "Player Two WINS!";
            }
        }

        else
        {
            if (playerOneTurn)
            {
                message.text = "Player Two's Turn";
                playerOneTurn = !playerOneTurn;
            }
            else
            {
                message.text = "Player One's Turn";
                playerOneTurn = !playerOneTurn;
            }
        }

        //updated square colors
        SetObjectColor(s1, 0);
        SetObjectColor(s2, 1);
        SetObjectColor(s3, 2);
        SetObjectColor(s4, 3);
        SetObjectColor(s5, 4);
        SetObjectColor(s6, 5);
        SetObjectColor(s7, 6);
        SetObjectColor(s8, 7);
        SetObjectColor(s9, 8);
    }

    // parse the lineArray to find completed squares
    // update the squareArray, number of completed squares, and score
    void CheckForCompletedSquares()
    {
        for (int i = 0; i < 9; i++)
        {
            int sidesOfSquares = 0;
            sidesOfSquares = lineArray[i, 0] + lineArray[i, 1] + lineArray[i, 2] + lineArray[i, 3];
            if (sidesOfSquares == 4 && squareArray[i] == 0)
            {
                if (playerOneTurn)
                {
                    squareArray[i] = 1;
                    numberOfCompletedSquares++;
                    playerOneScore++;
                }
                else
                {
                    squareArray[i] = 2;
                    numberOfCompletedSquares++;
                    playerTwoScore++;
                }
            }
        }

    }


    // Takes square and the squareArray index to change color and transparency
    void SetObjectColor(GameObject go, int index)
    {
        Color color1 = go.GetComponent<Renderer>().material.color;
        int colorCode = squareArray[index];

        if (colorCode == 0) //transparent
        {
            go.gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (colorCode == 1) //player one square
        {
            go.gameObject.GetComponent<Renderer>().enabled = true;
            color1.a = 1.0f;
            color1 = Color.green;
        }
        if (colorCode == 2) //player two square
        {
            go.gameObject.GetComponent<Renderer>().enabled = true;
            color1.a = 1.0f;
            color1 = Color.red;
        }

        go.GetComponent<Renderer>().material.color = color1;
    }

    // Called by LineCommand, passes name of line then updates the lineArray that line has been selected
    public void UpdateLineArray(string lineName)
    {

        if (lineName == "hl1")
        {
            lineArray[0, 0] = 1;
        }
        if (lineName == "hl2")
        {
            lineArray[1, 0] = 1;
        }
        if (lineName == "hl3")
        {
            lineArray[2, 0] = 1;
        }
        if (lineName == "hl4")
        {
            lineArray[0, 2] = 1; lineArray[3, 0] = 1;
        }
        if (lineName == "hl5")
        {
            lineArray[1, 2] = 1; lineArray[4, 0] = 1;
        }
        if (lineName == "hl6")
        {
            lineArray[5, 0] = 1; lineArray[2, 2] = 1;
        }
        if (lineName == "hl7")
        {
            lineArray[6, 0] = 1; lineArray[3, 2] = 1;
        }
        if (lineName == "hl8")
        {
            lineArray[7, 0] = 1; lineArray[4, 2] = 1;
        }
        if (lineName == "hl9")
        {
            lineArray[8, 0] = 1; lineArray[5, 2] = 1;
        }
        if (lineName == "hl10")
        {
            lineArray[6, 2] = 1;
        }
        if (lineName == "hl11")
        {
            lineArray[7, 2] = 1;
        }
        if (lineName == "hl12")
        {
            lineArray[8, 2] = 1;
        }
        if (lineName == "vl1")
        {
            lineArray[0, 3] = 1;
        }
        if (lineName == "vl2")
        {
            lineArray[3, 3] = 1;
        }
        if (lineName == "vl3")
        {
            lineArray[6, 3] = 1;
        }
        if (lineName == "vl4")
        {
            lineArray[0, 1] = 1; lineArray[1, 3] = 1;
        }
        if (lineName == "vl5")
        {
            lineArray[3, 1] = 1; lineArray[4, 3] = 1;
        }
        if (lineName == "vl6")
        {
            lineArray[6, 1] = 1; lineArray[7, 3] = 1;
        }
        if (lineName == "vl7")
        {
            lineArray[1, 1] = 1; lineArray[2, 3] = 1;
        }
        if (lineName == "vl8")
        {
            lineArray[4, 1] = 1; lineArray[5, 3] = 1;
        }
        if (lineName == "vl9")
        {
            lineArray[7, 1] = 1; lineArray[8, 3] = 1;
        }
        if (lineName == "vl10")
        {
            lineArray[2, 1] = 1;
        }
        if (lineName == "vl11")
        {
            lineArray[5, 1] = 1;
        }
        if (lineName == "vl12")
        {
            lineArray[8, 1] = 1;
        }

        UpdateGameBoard();
    }

    //Do a flashing halo to indicate player's turn and/or winner
}
