using UnityEngine;
using System.Collections;

public class SceneSwapChecker : MonoBehaviour
{
    public Transform Transformor;
    public int SpawnRadius;
    public GameObject MuseumRoom;
    public GameObject PaintingScene;
    public SceneOrchestrator Orchestrator;

    private bool isPaintingRoom = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float paintingDistance = Vector3.Distance(Transformor.position, transform.position);
	    
	    if (paintingDistance < SpawnRadius)
	    {
	        if (!isPaintingRoom)
	        {
                // swap to painting scene
                isPaintingRoom = true;
                Orchestrator.SwapScene(MuseumRoom, PaintingScene);
	            print("Sakura");
	        }
	    }
	    else
	    {
	        if (isPaintingRoom)
	        {
                isPaintingRoom = false;
                Orchestrator.SwapScene(PaintingScene, MuseumRoom);
	            print("Museum");
	        }
	    }
        
	}
}
