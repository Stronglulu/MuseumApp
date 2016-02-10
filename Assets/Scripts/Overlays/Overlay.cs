using UnityEngine;
using System.Collections;

public class Overlay : MonoBehaviour
{
    public float animationTime = 1;

    protected Renderer rend;
    protected float t;
    protected Function function;

    void Start()
    {
        rend = GetComponent<Renderer>();
        function = new WaveFunction();
    }
	
	void Update()
    {
        UpdateOverlay(function.Calc(t / animationTime));
        t += Time.deltaTime;
	}

    public virtual void UpdateOverlay(float val)
    {
        Color c = rend.material.color;
        c.a = val;
        rend.material.color = c;
    }
}
