using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour
{
    public GameObject overlayObject;

    private CardboardHead head;
    private Overlay overlay;
    private Material matIdle, matActive;
    private bool wasLookedAt;

    void Start()
    {
        head = Camera.main.GetComponent<StereoController>().Head;
        overlay = overlayObject.GetComponent<Overlay>();
        matIdle = Resources.Load<Material>("Materials/BarBG");
        matActive = Resources.Load<Material>("Materials/BarProgress");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
        if (isLookedAt && !wasLookedAt)
        {
            overlay.t = 0;
            GetComponent<Renderer>().material = matActive;

            Museum.Log(Time.time, "replay_extending");
        }
        else if (!isLookedAt)
        {
            GetComponent<Renderer>().material = matIdle;
        }

        wasLookedAt = isLookedAt;
    }
}
