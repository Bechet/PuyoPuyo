using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelectScript : MonoBehaviour
{
    private int indexSelectedMenu = 0;

    //For text Animation
    private bool bIsFading = true;
    private float minAlpha = 0.1F;
    private float maxAlpha = 1.5F;
    private float fadingSpeed = 0.05F;
    private Color colorForAlpha;

    private List<Text> listMenuText;
    private List<Color> listMenuColor;

    // Use this for initialization
    void Start()
    {
        //Text components
        this.listMenuText = new List<Text>();
        listMenuText.Add(GameObject.FindGameObjectWithTag(Tags.menuPlay).GetComponent<Text>());
        listMenuText.Add(GameObject.FindGameObjectWithTag(Tags.menuOption).GetComponent<Text>());
        listMenuText.Add(GameObject.FindGameObjectWithTag(Tags.menuCredit).GetComponent<Text>());

        //Color components
        this.listMenuColor = new List<Color>();
        this.listMenuColor.Add(new Color(1F, 0, 0, 1));
        this.listMenuColor.Add(new Color(0, 0.8F, 0, 1));
        this.listMenuColor.Add(new Color(0, 0, 1F, 1));
        this.indexSelectedMenu = 0;
        this.colorForAlpha = this.listMenuColor[this.indexSelectedMenu];

        //Start fading animation for the selected element
        menuTextAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        this.modifyAlpha();

        //this.controlConfigManager.Update();
        this.CheckKeyPressed();
    }

    private void menuTextAnimation()
    {
        InitAnimation();
        this.listMenuText[this.indexSelectedMenu].color = this.colorForAlpha;
    }

    private void InitAnimation()
    {
        for(int i=0; i<this.listMenuText.Count;i++)
        {
            this.listMenuText[i].color = this.listMenuColor[i];
        }
        this.colorForAlpha = this.listMenuColor[this.indexSelectedMenu];
    }

    private void modifyAlpha()
    {
        if (this.indexSelectedMenu >= 0 && this.indexSelectedMenu < 3)
        {
            this.listMenuText[this.indexSelectedMenu].color = this.colorForAlpha;
            if (this.bIsFading)
            {
                this.colorForAlpha.a -= this.fadingSpeed;
                if (this.colorForAlpha.a < this.minAlpha)
                {
                    this.bIsFading = false;
                }
            }
            else
            {
                this.colorForAlpha.a += this.fadingSpeed;
                if (this.colorForAlpha.a > this.maxAlpha)
                {
                    this.bIsFading = true;
                }
            }
        }
    }

    private void CheckKeyPressed()
    {
        if (Input.GetButtonDown("Vertical0"))
        {
            this.indexSelectedMenu = StaticMethode.mod(this.indexSelectedMenu - Mathf.FloorToInt(Input.GetAxisRaw("Vertical0")), this.listMenuText.Count);
            InitAnimation();
        }
        if (Input.GetButtonDown("A0"))
        {
            this.ItemSelected(this.indexSelectedMenu);
        }
    }

    private void ItemSelected(int indexSelectedElement)
    {
        switch(indexSelectedElement)
        {
            case 0:
                SceneManager.LoadScene("CharacterSelect");
                break;
            case 1:
                SceneManager.LoadScene("Option");
                break;
            case 2:
                SceneManager.LoadScene("Credit");
                break;

        }
    }


    
}
