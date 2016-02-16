using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {
    private CardboardHead head;
    float timer, scale;
    Material barBGMat, barSelectedMat;
    GameObject progressBar;
    public string nextScene;
    public float loadTime;

	// Use this for initialization
	void Start () {
        head = Camera.main.GetComponent<StereoController>().Head;
        timer = 0;
        barBGMat = Resources.Load("Materials/barBG") as Material;
        barSelectedMat = Resources.Load("Materials/barSelected") as Material;
        progressBar = GameObject.Find("Bar Progress Pivot");
	    
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
        if (isLookedAt)
        {
            this.GetComponent<Renderer>().material = barSelectedMat;
            scale = (5f / loadTime) * timer;
            Debug.Log(scale + " " + timer);
            progressBar.transform.localScale = new Vector3(scale, 0.01f, 1);
            timer += Time.deltaTime;
            if (timer > loadTime)
                SceneManager.LoadScene(nextScene);
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.white;
            this.GetComponent<Renderer>().material = barBGMat;
            progressBar.transform.localScale = new Vector3(0, 0.01f, 1);
            timer = 0;
        }
	}

    void OnGUI()
    {

    }
}
