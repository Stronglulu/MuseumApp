using UnityEngine;
using System.Collections;

public class SceneSwapChecker : MonoBehaviour
{
    public Transform Transformor;
    public int ThresholdZ;
    public GameObject MuseumRoom;
    public GameObject PaintingScene;
    public ScreenFader fadert;

    private bool isPaintingRoom = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Transformor.position.z > ThresholdZ)
	    {
	        if (!isPaintingRoom)
	        {
                isPaintingRoom = true;
	            //PaintingScene.SetActive(true);
	            //MuseumRoom.SetActive(false);
                fadert.EndScene(MuseumRoom, PaintingScene);
	            print("Sakura");
	        }
	    }
	    else
	    {
	        if (isPaintingRoom)
	        {
                isPaintingRoom = false;
                fadert.EndScene(PaintingScene, MuseumRoom);
	            //PaintingScene.SetActive(false);
	            //MuseumRoom.SetActive(true);
	            print("Museum");
	        }
	    }
	}
}
