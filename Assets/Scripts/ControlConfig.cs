using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ControlConfig
{
    public string playerIndex;
    public string up;
    public string left;
    public string down;
    public string right;
    public string A;
    public string B;
    public string X;
    public string Y;

    public ControlConfig()
    {
        this.Initialisation(1);
    }

    public void Initialisation(int playerIndex)
    {
        this.playerIndex = playerIndex.ToString();
        this.up = "up";
        this.left = "left";
        this.down = "down";
        this.right = "right";
        this.A = "X";
        this.B = "C";
        this.X = "S";
        this.Y = "D";
    }

    public void updateControlConfig()
    {
        GameObject.FindGameObjectWithTag("controlConfigPlayerIndex").GetComponent<Text>().text = this.playerIndex;
        GameObject.FindGameObjectWithTag("controlConfigUp").GetComponent<Text>().text = this.up;
        GameObject.FindGameObjectWithTag("controlConfigLeft").GetComponent<Text>().text = this.left;
        GameObject.FindGameObjectWithTag("controlConfigDown").GetComponent<Text>().text = this.down;
        GameObject.FindGameObjectWithTag("controlConfigRight").GetComponent<Text>().text = this.right;
        GameObject.FindGameObjectWithTag("controlConfigA").GetComponent<Text>().text = this.A;
        GameObject.FindGameObjectWithTag("controlConfigB").GetComponent<Text>().text = this.B;
        GameObject.FindGameObjectWithTag("controlConfigX").GetComponent<Text>().text = this.X;
        GameObject.FindGameObjectWithTag("controlConfigY").GetComponent<Text>().text = this.Y;
    }
}
