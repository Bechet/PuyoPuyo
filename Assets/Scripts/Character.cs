using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character
{
    public Image image;
    public string name;

    public Character()
    {

    }

    public Character(Image image, string name)
    {
        this.image = image;
        this.name = name;
    }

}
