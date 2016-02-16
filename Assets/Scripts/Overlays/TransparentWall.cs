using UnityEngine;
using System.Collections;

public class TransparentWall : Overlay {
    float newAlpha;
    bool decreasing;
    float speed = 0.25f;
    float pause = 1; // Wait 1 sec when fully opaque/transparent.


	// Use this for initialization
    void Start()
    {
        base.Start();
        //color = rend.material.color;
        newAlpha = 1;
        decreasing = true;
	}
	
	// Update is called once per frame
    public override void UpdateOverlay( float timer)
    {
        if(timer > 1/speed + pause)
        {
            // Reset timer.
            timer = 0;
        }
        else if(timer > (1/speed))
        {
            // Pause when fully transparant or opaque.
            timer += Time.deltaTime;
        }
        else if (newAlpha > 0 && decreasing)
        {
            newAlpha -= Time.deltaTime * speed;
            timer += Time.deltaTime;
        }
        else if(newAlpha < 1 && !decreasing)
        {
            newAlpha += Time.deltaTime * speed;
            timer += Time.deltaTime;
        }
        else
        {
            decreasing = !decreasing;
        }

        rend.material.SetFloat("_Blend", newAlpha);
        //color.a = newAlpha;
        //rend.material.color = color;
	}
}
