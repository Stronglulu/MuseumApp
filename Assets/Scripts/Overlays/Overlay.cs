using UnityEngine;
using System.Collections;

public class Overlay : MonoBehaviour
{
    public float animationTime = 1;

    private Renderer rend;
    private float t;
    private Function function;

    void Start()
    {
        rend = GetComponent<Renderer>();
        function = new WaveFunction();
    }
	
	void Update()
    {
        Color c = rend.material.color;
        c.a = function.Calc(t / animationTime);
        rend.material.color = c;
        t += Time.deltaTime;
	}
}
