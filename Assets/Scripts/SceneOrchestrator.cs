﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneOrchestrator : MonoBehaviour
{
    public Image FadeImg;
    public float fadeOutSpeed = 7f;
    public float fadeInSpeed = 5f;
    public bool isFadingIn = true;
    private bool IsFadingOut = false;
    GameObject oldScene;
    GameObject newScene;

    public static string currentScene = "StandardMuseumScene";

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // [SWAPPING SCENES]
        if (isFadingIn)
            StartScene();
        if (IsFadingOut)
            FadeOut();
    }

    public void SwapScene(GameObject oldScene, GameObject newScene)
    {
        this.oldScene = oldScene;
        this.newScene = newScene;

        isFadingIn = false;
        IsFadingOut = true;
        FadeOut();
    }



    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeInSpeed * Time.deltaTime);
    }


    void FadeToWhite()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.white, fadeOutSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.01f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            isFadingIn = false;
        }
    }

    public void FadeOut()
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;

        // Start fading towards black.
        FadeToWhite();

        // If the screen is almost black...
        if (FadeImg.color.a >= 0.99f)
        {
            newScene.SetActive(true);
            oldScene.SetActive(false);
            IsFadingOut = false;
            isFadingIn = true;
            StartScene();
        }
        // ... reload the level
        //SceneManager.LoadScene(SceneNumber);
    }
}