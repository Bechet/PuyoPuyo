using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisManager{
    public int verticalLeftJoystic = 0;
    public int horizontalLeftJoystic = 0;
    public int verticalDpad = 0;
    public int horizontalDpad = 0;
    public float deathJoystic = 0.19F;

    public int joysticInitialSpeed = 5;
    public int joysticSpeed = 5;
    private int maxCounter = 15;

    public int UpdateVerticalLeftJoystic(float axisValue)
    {
        
        int axisSave = this.verticalLeftJoystic;
        int addedValue = Mathf.RoundToInt(axisValue * joysticSpeed);
        //axisSave = getAxisSaveValue(axisValue, addedValue);
        

        if (axisValue > deathJoystic)
        {
            if (axisSave > 0)
            {
                axisSave += addedValue;
            }
            else
            {
                axisSave = addedValue;
            }
        }
        else if (axisValue < -deathJoystic)
        {
            if (axisSave > 0)
            {
                axisSave = addedValue;
            }
            else
            {
                axisSave += addedValue;
            }
        }
        else
        {
            axisSave = 0;
        }

        int returnValue = 0;
        //Move 1 to left
        if (axisSave > 0 && this.verticalLeftJoystic < 0)
        {
            returnValue = 1;
        }
        //Move 1 right
        else if (axisSave < 0 && this.verticalLeftJoystic > 0)
        {
            returnValue = -1;
        }
        else if (Mathf.Abs(axisSave / maxCounter) > 1)
        {
            returnValue = (int)axisSave / maxCounter;
            axisSave = 0;
        }
        this.verticalLeftJoystic = axisSave;
        return returnValue;
    }


    public int UpdateHorizontalLeftJoystic(float axisValue)
    {
        if (axisValue > deathJoystic || axisValue < -deathJoystic)
        {
            Debug.Log(this.horizontalLeftJoystic);
        }
        int axisSave = this.horizontalLeftJoystic;
        int addedValue = Mathf.RoundToInt(axisValue * joysticSpeed);
        if (axisValue > deathJoystic)
        {
            if (axisSave > 0)
            {
                axisSave += addedValue;
            }
            else
            {
                axisSave = addedValue;
            }
        }
        else if (axisValue < -deathJoystic)
        {
            if (axisSave > 0)
            {
                axisSave = addedValue;
            }
            else
            {
                axisSave += addedValue;
            }
        }
        else
        {
            //Debug.Log("hee " + axisValue);
            axisSave = 0;
        }

        int returnValue = 0;
        //Move 1 to left
        if (axisSave > 0 && this.horizontalLeftJoystic < 0)
        {
            returnValue = 1;
        }
        //Move 1 right
        else if (axisSave < 0 && this.horizontalLeftJoystic > 0)
        {
            returnValue = -1;
        }
        else if (Mathf.Abs(axisSave / maxCounter) > 1)
        {
            returnValue = (int)axisSave / maxCounter;
            axisSave = 0;
        }
        this.horizontalLeftJoystic = axisSave;
        return returnValue;
    }




}
