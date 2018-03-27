using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{

    private List<string> listKeyStringPressed;
    private List<string> listKeyStringPossible;
    public ControlManager(List<string> listKeyStringPressed)
    {
        this.listKeyStringPressed = listKeyStringPressed;
        this.listKeyStringPossible = new List<string>();
        this.listKeyStringPossible.Add("z");
        this.listKeyStringPossible.Add("q");
        this.listKeyStringPossible.Add("s");
        this.listKeyStringPossible.Add("d");
        this.listKeyStringPossible.Add("enter");
        this.listKeyStringPossible.Add("space");
        this.listKeyStringPossible.Add("up");
        this.listKeyStringPossible.Add("left");
        this.listKeyStringPossible.Add("down");
        this.listKeyStringPossible.Add("right");


    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {

        }
    }
}
