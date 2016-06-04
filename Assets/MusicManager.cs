using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    string currentScene;
    AudioSource audioSource;
    float fadeSpeed = 0.01f;
    float maxVolume = 0.53f;

	// Use this for initialization
	void Start () {
        currentScene = SceneOrchestrator.currentScene;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(SceneOrchestrator.currentScene);
        currentScene = SceneOrchestrator.currentScene;
        if (currentScene == "PaintingSceneSakura")
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            if (audioSource.volume < maxVolume)
                audioSource.volume += fadeSpeed;
        }
        else
        {
            audioSource.volume -= fadeSpeed;
            if (audioSource.volume == 0)
                audioSource.Stop();
        }
	}
}
