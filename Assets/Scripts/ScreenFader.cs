﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    private bool isFading = false;
    GameObject oldScene;
    GameObject newScene;

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();
        if (isFading)
        {
            DarkFade();
        }
    }


    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.white, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public void EndScene(GameObject oldScene, GameObject newScene)
    {
        this.oldScene = oldScene;
        this.newScene = newScene;

        isFading = true;
        DarkFade();
    }

    public void DarkFade()
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;

        // Start fading towards black.
        FadeToBlack();

        // If the screen is almost black...
        if (FadeImg.color.a >= 0.95f)
        {
            newScene.SetActive(true);
            oldScene.SetActive(false);
            isFading = false;
            sceneStarting = true;
            StartScene();
        }
        // ... reload the level
        //SceneManager.LoadScene(SceneNumber);
    }
}