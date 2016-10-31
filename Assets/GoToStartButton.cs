using UnityEngine;
using System.Collections;

public class GoToStartButton : MonoBehaviour {
    public GameObject player;

    private Vector3 startingPosition;
    private Quaternion startingRotation;
    // Use this for initialization
    void Start () {
        // obtain the starting position of the player
        startingPosition = player.transform.position;
        startingRotation = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(1))
        {
            player.transform.position = startingPosition;
        }
	}
}
