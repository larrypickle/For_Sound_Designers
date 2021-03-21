using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public Image fadeIn;
    void Start()
    {
        fadeIn.canvasRenderer.SetAlpha(1.0f);
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeIn()
    {
        fadeIn.CrossFadeAlpha(0, 20, false);
    }
}
