using UnityEngine;
using System.Collections;

public class IllusionSwapChecker : MonoBehaviour {


    public Transform PlayerTransform;
    public float SpawnRadius;
    public string illusion;
    //public SceneOrchestrator Orchestrator;
    bool illusionActive = false;

    //public Collider EntranceCollider;
    //public Collider ExitCollider;

    //protected CardboardHead head;

    //private bool IsSwappingToNextScene = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	    float paintingDistance = Vector3.Distance(PlayerTransform.position, transform.position);

        if (paintingDistance < SpawnRadius)
        {
            if (!illusionActive)
            {
                
                illusionActive = true;
                SceneOrchestrator.currentScene = illusion;
                
            }

        }
        else
        {
            if (illusionActive)
            {
                SceneOrchestrator.currentScene = "StandardMuseumScene";
                illusionActive = false;
            }

            
        }
	}
}

