using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public float loadTime;

    protected string nextScene;
    protected float timer, scale;
    protected Material barBGMat, barSelectedMat;
    protected GameObject progressBar;

    private CardboardHead head;

	void Start()
    {
        Load();
	}

    public virtual void Load()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        timer = 0;
        barBGMat = Resources.Load("Materials/barBG") as Material;
        barSelectedMat = Resources.Load("Materials/barSelected") as Material;
        progressBar = transform.parent.FindChild("Bar Progress Pivot").gameObject;
    }
	
	void Update()
    {
        RaycastHit hit;
        bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
        if (isLookedAt && IsActive())
        {
            this.GetComponent<Renderer>().material = barSelectedMat;
            scale = (5f / loadTime) * timer;
            Debug.Log(scale + " " + timer);
            progressBar.transform.localScale = new Vector3(scale, 0.01f, 1);
            timer += Time.deltaTime;

            if (timer > loadTime)
            {
                SceneManager.LoadScene(nextScene);
                OnNextScene();
            }
        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.white;
            this.GetComponent<Renderer>().material = barBGMat;
            progressBar.transform.localScale = new Vector3(0, 0.01f, 1);
            timer = 0;
        }
	}

    public virtual void OnNextScene() { }

    public virtual bool IsActive()
    {
        return true;
    }

    void OnGUI()
    {

    }
}
