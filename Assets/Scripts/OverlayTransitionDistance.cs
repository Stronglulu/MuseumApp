using UnityEngine;
using System.Collections;

public class OverlayTransitionDistance : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.005f;
    float maxDistance = 4;
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
        Debug.Log(rend.material.GetFloat("_Blend"));
        if (distance < maxDistance)
        {
            if (increase)
                rend.material.SetFloat("_Blend", rend.material.GetFloat("_Blend") + speed);
            else
                rend.material.SetFloat("_Blend", rend.material.GetFloat("_Blend") - speed);

            if (rend.material.GetFloat("_Blend") >= 1 || rend.material.GetFloat("_Blend") <= 0)
                increase = !increase;
        }
    }
}
