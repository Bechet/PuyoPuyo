using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation{

    private bool isFading = true;
    private float alpha = 1F;
    private float minAlpha;
    private float maxAlpha;
    private float speed;
    private Color color;
    public FadeAnimation(Color color, float minAlpha, float maxAlpha, float speed)
    {
        this.color = color;
        this.minAlpha = minAlpha;
        this.maxAlpha = maxAlpha;
        this.speed = speed;
    }
    public float getAlpha()
    {
        if (isFading)
        {
            if (this.alpha < minAlpha)
            {
                this.isFading = false;
            } else
            {
                this.alpha -= this.speed;
            }
        } else
        {
            if(this.alpha > maxAlpha)
            {
                this.isFading = true;
            } else
            {
                this.alpha += this.speed;
            }
        }
        return alpha;
    }

    public Color getColor()
    {
        color.a = getAlpha();
        return color;
    }
}
