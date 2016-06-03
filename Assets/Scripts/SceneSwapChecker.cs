using UnityEngine;
using System.Collections;

public class SceneSwapChecker : MonoBehaviour
{
    public Transform PlayerTransform;
    public int SpawnRadius;
    public GameObject CurrentScene;
    public GameObject NextScene;
    public SceneOrchestrator Orchestrator;

    private bool IsSwappingToNextScene = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float paintingDistance = Vector3.Distance(PlayerTransform.position, transform.position);

	    if (paintingDistance < SpawnRadius)
	    {
	        if (!IsSwappingToNextScene)
	        {
	            // swap to painting scene
	            IsSwappingToNextScene = true;
	            Orchestrator.SwapScene(CurrentScene, NextScene);
	        }
	    }
	    else
	    {
	        if (IsSwappingToNextScene)
	        {
	            IsSwappingToNextScene = false;
	        }
	    }
        /**
	    else
	    {
	        if (IsSwappingToNextScene)
	        {
                //swap to Museum
                IsSwappingToNextScene = false;
                Orchestrator.SwapScene(NextScene, CurrentScene);
	        }
	    }
        **/
	}
}
