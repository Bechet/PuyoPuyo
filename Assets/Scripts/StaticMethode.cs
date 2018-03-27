using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMethode
{
    public static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}
