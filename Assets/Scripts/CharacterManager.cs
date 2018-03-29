using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    List<Character> listCharacter;
    private int nbCharacter;
    List<Player> listPlayer;
    private int xMax;
    private int yMax;
    public int xInit;
    public int yInit;
    public int xTranslation;
    public int yTranslation;

    public int nbPlayer;

    // Use this for initialization
    void Start()
    {
        LoadAllCharacters();
        this.listPlayer = new List<Player>();
        this.xMax = 3;
        this.yMax = 3;

        for (int i = 0; i < this.nbPlayer; i++)
        {
            Player player = new Player(i);
            player.UpdateCharacter(GetCharacter(player.xCharacterSelected, player.yCharacterSelected));
            Debug.Log(player.character);
            this.listPlayer.Add(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckButtonPressed();
        FrameFadeAnimation();
        DrawPlayersCharacter();
    }

    private void LoadAllCharacters()
    {
        this.listCharacter = new List<Character>();
        GameObject characterImageContainer = GameObject.FindGameObjectWithTag("CharacterImageContainer");
        Image[] listImages = characterImageContainer.GetComponentsInChildren<Image>();
        foreach (Image image in listImages)
        {
            this.listCharacter.Add(new Character(image, image.name));
        }
        this.nbCharacter = listImages.Length;
    }

    private void CheckButtonPressed()
    {

        for (int i = 0; i < this.listPlayer.Count; i++)
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

    private void DrawPlayersCharacter()
    {
        foreach(Player player in listPlayer)
        {
            player.selectedCharacterImage.sprite = player.character.image.sprite;
        }
    }

    private Character GetCharacter(int x, int y)
    {
        return this.listCharacter[0];
    }
}

