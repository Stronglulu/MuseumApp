using UnityEngine;
using System.Collections;

public class SceneSwapChecker : MonoBehaviour
{
    public Transform Transformor;
    public int ThresholdZ;
    public GameObject MuseumRoom;
    public GameObject PaintingScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Transformor.position.z > ThresholdZ)
	    {
	        if (!PaintingScene.activeSelf)
	        {
	            PaintingScene.SetActive(true);
	            MuseumRoom.SetActive(false);
	            print("Sakura");
	        }
	    }
	    else
	    {
	        if (!MuseumRoom.activeSelf)
	        {
	            PaintingScene.SetActive(false);
	            MuseumRoom.SetActive(true);
	            print("Museum");
	        }
	    }
	}
}
