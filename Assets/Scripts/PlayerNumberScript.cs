using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNumberScript : MonoBehaviour {
    private List<Color> listColor;
    private int indexSelected;
    private FadeAnimation fadeAnimation;
    private Text[] tabMode;
    private int verticalValue;


	// Use this for initialization
	void Start () {
        this.indexSelected = 0;
        GameObject modeContainer = GameObject.FindGameObjectWithTag("ModeContainer");
        tabMode = modeContainer.GetComponentsInChildren<Text>();

        listColor = new List<Color>();
        //Add Red, Green, Blue, Violet
        listColor.Add(new Color(1F, 0, 0, 1));
        listColor.Add(new Color(0, 0.8F, 0, 1));
        listColor.Add(new Color(0, 0, 1F, 1));

        //Init Text Color
        for(int i=0; i < tabMode.Length; i++)
        {
            tabMode[i].color = listColor[i];
        }

        fadeAnimation = new FadeAnimation(listColor[indexSelected], 0.3F, 1.2F, 0.07F);
    }

    // Update is called once per frame
    void Update () {
        this.FadeSelectedItem();
        this.UpdateSelectedIndex();

    }

    private void FadeSelectedItem()
    {
        tabMode[indexSelected].color = fadeAnimation.getColor();
    }

    private void UpdateSelectedIndex()
    {
        verticalValue = StaticMethode.CheckButtonDownByPlayerNumber("Vertical", 0);
        if (verticalValue != 0)
        {
            tabMode[indexSelected].color = listColor[indexSelected];
            this.indexSelected = StaticMethode.mod(this.indexSelected - verticalValue, this.tabMode.Length);
            this.fadeAnimation.Reset(listColor[indexSelected]);
        }
    }

}
