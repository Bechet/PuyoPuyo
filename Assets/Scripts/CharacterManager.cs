using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    List<Character> listCharacter;
    List<Player> listPlayer;
    private int xMax;
    private int yMax;
    public int xInit;
    public int yInit;
    public int xTranslation;
    public int yTranslation;

    public int nbPlayer;
    private Canvas canvas;

    // Use this for initialization
    void Start()
    {
        this.canvas = GameObject.FindGameObjectWithTag("CharacterSelectCanvas").GetComponent<Canvas>();
        this.listCharacter = new List<Character>();
        LoadAllCharacters();
        this.listPlayer = new List<Player>();
        this.xMax = 3;
        this.yMax = 3;

        for (int i = 0; i < this.nbPlayer; i++)
        {
            this.listPlayer.Add(new Player(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckButtonPressed();
        FrameFadeAnimation();
    }

    private void LoadAllCharacters()
    {
        Image[] listImages = canvas.GetComponentsInChildren<Image>();
        foreach (Image image in listImages)
        {
            this.listCharacter.Add(new Character(image, image.name));
        }
    }

    private void CheckButtonPressed()
    {
        this.listPlayer[1].UpdateFrame(this.xInit, this.yInit, this.xTranslation, this.yTranslation);
        for (int i = 1; i < this.listPlayer.Count; i++)
        {
            if (Input.GetButtonDown("Horizontal" + i))
            {
                this.listPlayer[i].UpdateX(Input.GetAxisRaw("Horizontal" + i), this.xMax);
                this.listPlayer[i].UpdateFrame(this.xInit, this.yInit, this.xTranslation, this.yTranslation);
            }
            if (Input.GetButtonDown("Vertical" + i))
            {
                this.listPlayer[i].UpdateY(Input.GetAxisRaw("Vertical" + i), this.yMax);
                this.listPlayer[i].UpdateFrame(this.xInit, this.yInit, this.xTranslation, this.yTranslation);
            }
            //Update for joystic users (Horizontal)
            int returnedHorizontalValue = listPlayer[i].axisManager.UpdateHorizontalLeftJoystic(Input.GetAxis("Horizontal" + i));
            if (returnedHorizontalValue != 0)
            {
                this.listPlayer[i].UpdateX(returnedHorizontalValue, this.xMax);
                this.listPlayer[i].UpdateFrame(this.xInit, this.yInit, this.xTranslation, this.yTranslation);
            }


            //Update for joystic users (Vertical)
            int returnedVerticalValue = listPlayer[i].axisManager.UpdateVerticalLeftJoystic(Input.GetAxis("Vertical" + i));
            if (returnedVerticalValue != 0)
            {
                this.listPlayer[i].UpdateY(returnedVerticalValue, this.yMax);
                this.listPlayer[i].UpdateFrame(this.xInit, this.yInit, this.xTranslation, this.yTranslation);
            }
        }
    }

    private void FrameFadeAnimation()
    {
        foreach(Player player in listPlayer)
        {
            player.UpdateFrameColor();
        }
    }

}

