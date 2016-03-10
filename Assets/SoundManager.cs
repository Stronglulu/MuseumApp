using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour {

    Room room;
    Floor floor;
    AudioClip clip;
    string clipName;
    AudioSource audio;

	// Use this for initialization
	void Start () {

        audio = this.GetComponent<AudioSource>();
        audio.loop = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnLevelWasLoaded(int level)
    {

        clipName = "";

        //Debug.Log((Museum.CurrentFloor.rooms.Count == 3)  + " " + (Museum.CurrentFloor.rooms[0].sound == "museumAmbience"));
        if (Museum.CurrentFloor.rooms.Count == 3 && Museum.CurrentFloor.rooms[0].sound == "museumAmbience")
        {
            audio.clip = (AudioClip)Resources.Load("Sound/" + Museum.CurrentFloor.rooms[0].sound);
            if(!audio.isPlaying)
                audio.Play();
        }
        else
        {
            try
            {
                clipName = Museum.CurrentFloor.CurrentRoom.sound;
            }
            catch (Exception e)
            {
                audio.Stop();
            }

            if (clipName == "None")
            {
                audio.Stop();
            }
            else if (clipName != "")
            {
                string path = "Sound/" + Museum.CurrentFloor.CurrentRoom.sound;

                clip = (AudioClip)Resources.Load(path);
                audio.clip = clip;
                audio.Play();

            }
        }
    }
}
