using System;
using UnityEngine;
using System.Collections;

public class OverlayTransitionDistance : MonoBehaviour
{
    public GameObject player;
    public float transitionTime = 2f;
    public bool timeBased = false;

    float maxDistance = 4f;
    float scaledDistance = 1f;
    float distance;
    Renderer rend;
    bool increase = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < maxDistance)
        {
            if (timeBased)
            {
                scaledDistance = Math.Max(0, scaledDistance - Time.deltaTime/transitionTime);
            }
            else {
                scaledDistance = Math.Max((distance - 2f) / (maxDistance - 2f), 0);
            }
            rend.material.SetFloat("_Blend", scaledDistance);
        }
        else
        {
            if (timeBased)
            {
                scaledDistance = Math.Min(1, scaledDistance + Time.deltaTime/transitionTime);
                rend.material.SetFloat("_Blend", scaledDistance);
            }
            else
            {
                rend.material.SetFloat("_Blend", 1);
            }            
            //increase = false;
        }
    }
}
