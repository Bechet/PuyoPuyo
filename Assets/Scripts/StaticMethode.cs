using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMethode
{
    public static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public static int CheckButtonDownByPlayerNumber(string buttonName, int number)
    {
        
        if (Input.GetButtonDown(buttonName + number))
        {
            return Mathf.FloorToInt(Input.GetAxisRaw(buttonName + number));
        } else
        {
            return 0;
        }
    }

}
