using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    //private CardboardHead head;
    private Camera camera;
    float timer, scale;
	
	// Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
        bool isLookedAt = GetComponent<Collider>().Raycast(new Ray(camera.transform.position, camera.transform.forward), out hit, Mathf.Infinity);
        if (isLookedAt)
        {


            timer += Time.deltaTime;
            scale = 5 / 3 * timer;
            this.transform.localScale = new Vector3(scale, 0.01f, 1);
            //if (timer > 3)
            // Application.LoadLevel("basicRoom");
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.white;
            this.transform.localScale = new Vector3(0, 0.01f, 1);
            timer = 0;
        }
    }
}
