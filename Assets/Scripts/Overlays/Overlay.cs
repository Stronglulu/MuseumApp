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
        UpdateOverlay();
        t += Time.deltaTime;
	}

    public virtual void UpdateOverlay()
    {
        Color c = rend.material.color;
        c.a = function.Calc(t / animationTime);
        rend.material.color = c;
    }
}
