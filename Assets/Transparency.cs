using UnityEngine;
using System.Collections;

public class Transparency : MonoBehaviour {

    float alpha = 1;
    Color color;
    Renderer rend;
    Renderer[] renderers;

	// Use this for initialization
	void Start () {
        //rend = GetComponent<Renderer>();
        //color = rend.material.color;

        renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 1);
        
	}
	
	// Update is called once per frame
	void Update () {

        alpha -= 0.005f;
        if (alpha > 0)
        {
            renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, alpha);
        }	
	}
}
