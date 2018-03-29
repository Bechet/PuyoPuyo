using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private int number;
    public Character character;
    public int xCharacterSelected;
    public int yCharacterSelected;
    private Image frame;
    private Color color;
    public Image selectedCharacterImage;
    public AxisManager axisManager;
    public FadeAnimation fadeAnimation;
    public Player(int number)
    {
        this.axisManager = new AxisManager();
        this.number = number;
        this.frame = GameObject.FindGameObjectWithTag("Frame"+this.number).GetComponent<Image>();
        this.selectedCharacterImage = GameObject.FindGameObjectWithTag("SelectedCharacterImage" + this.number).GetComponent<Image>();
        switch (number)
        {
            case 0:
                this.color = new Color(0, 0, 1F, 1F);
                this.xCharacterSelected = 0;
                this.yCharacterSelected = 2;
                break;

            case 1:
                this.color = new Color(1F, 0, 0, 1F);
                this.xCharacterSelected = 2;
                this.yCharacterSelected = 2;
                break;
            case 2:
                this.color = new Color(0, 1F, 0, 1F);
                this.xCharacterSelected = 0;
                this.yCharacterSelected = 0;
                break;
            case 3:
                this.color = new Color(1F, 1F, 0, 1F);
                this.xCharacterSelected = 2;
                this.yCharacterSelected = 2;
                break;
        }

        this.fadeAnimation = new FadeAnimation(this.color, 0.3f, 1.3f, 0.07f);

    }

    /**
     * This methode updates the xCharacterSelected value when the player is choosing his/her character
     */
    public void UpdateX(float value, int xMax)
    {
        this.xCharacterSelected = StaticMethode.mod((this.xCharacterSelected + Mathf.FloorToInt(value)), xMax);
        //Debug.Log(xCharacterSelected);
    }

    /**
     * This methode updates the xCharacterSelected value when the player is choosing his/her character
     */
    public void UpdateY(float value, int yMax)
    {
        this.yCharacterSelected = StaticMethode.mod((this.yCharacterSelected + Mathf.FloorToInt(value)), yMax);
        //Debug.Log(yCharacterSelected);
    }

    public void UpdateFrame(int xInit, int yInit, int xTranslation, int yTranslation)
    {
        this.frame.transform.position = new Vector3(xInit+(xTranslation*this.xCharacterSelected), yInit + (yTranslation*this.yCharacterSelected), 0);
    }

    public void UpdateFrameColor()
    {
        this.frame.GetComponent<Image>().color = this.fadeAnimation.getColor();
    }

    public void UpdateCharacter(Character character)
    {
        this.character = character;
    }

    public void SetFrame(Image image)
    {
        this.frame = image;
    }



}
