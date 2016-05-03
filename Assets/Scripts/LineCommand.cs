using UnityEngine;
using System.Collections;

public class LineCommand : MonoBehaviour
{
    Vector3 originalPosition;

    private string objectName;
    private Color linecolor;
    private GameManager gm;
    private bool selected;


    // Use this for initialization
    void Start()
    {
        // Grab the original local position and color of the line when the app starts.
        originalPosition = this.transform.localPosition;
        linecolor = this.gameObject.GetComponent<Color>();
        objectName = this.gameObject.name;
        Debug.Log(objectName + " has been initalized.");
        gm = GameObject.Find("GameBoard").GetComponent<GameManager>();
        selected = false;
    }

    // Called by GazeGestureManager when the user's gaze hovers on hologram
    void OnHover()
    {
        if (!selected)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow; // highlight line
            Debug.Log(objectName + ": yellow");
        }

    }

    // Called by GazeGestureManager when the user's gaze hovers off of the focused hologram
    void OffHover()
    {
        if (!selected)
        {
            gameObject.GetComponent<Renderer>().material.color = linecolor; // un-highlight line
        }

    }

    // Called by GazeGestureManager when the user performs a Select gesture
    // Called by SpeechManager when the user says the "Select" command
    void OnSelect()
    {
        // change color of line when selected
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log(objectName + ": red");
        gm.UpdateLineArray(objectName);
        selected = true;

    }

    // Called by SpeechManager when the user says the "Reset game" command
    void OnReset()
    {
        // change color of line when reset
        gameObject.GetComponent<Renderer>().material.color = linecolor;
        selected = false;
    }
}


