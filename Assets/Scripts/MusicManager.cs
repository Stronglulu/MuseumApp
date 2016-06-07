using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    string currentScene;
    AudioSource audioSource;
    float fadeInSpeed = 0.01f;
    float fadeOutSpeed = 0.02f;
    float maxVolume = 0.53f;
    public string illusion;

	// Use this for initialization
	void Start () {
        currentScene = SceneOrchestrator.currentScene;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentScene = SceneOrchestrator.currentScene;
        if (currentScene == illusion)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();

            if (audioSource.volume < maxVolume)
                audioSource.volume += fadeInSpeed;
        }
        else
        {
            audioSource.volume -= fadeOutSpeed;
        }
	}
}
