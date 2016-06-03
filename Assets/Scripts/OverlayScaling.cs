using UnityEngine;
using System.Collections;

public class OverlayScaling : MonoBehaviour {

    public GameObject player;
    public float maxDist = 4;
    public float minDist = 1;
    public float maxScaleX = 7.3f;
    public float minScaleX = 0.88f;

    float minScaleZ = 0.58f;
    float distance, scaling, newScale;
    Vector3 scale;

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance < maxDist)
        {
            //%of scale increase/decrease
            scaling = 1 - ((distance - minDist) / (maxDist - minDist));

            //Absolute increase/decrease
            newScale = (maxScaleX - minScaleX) * scaling;

            transform.localScale = new Vector3(minScaleX + newScale, transform.localScale.y, minScaleZ + newScale);
        }

	}
}
