using UnityEngine;
using System.Collections;

public class OverlayScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.localScale.x < 7.3f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y, transform.localScale.z + 0.01f);
        }
	}
}
