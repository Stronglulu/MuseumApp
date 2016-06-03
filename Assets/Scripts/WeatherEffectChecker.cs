using UnityEngine;
using System.Collections;

public class WeatherEffectChecker : MonoBehaviour
{
    public Transform PlayerTransform;
    public int SpawnRadius;
    public ParticleSystem WeatherParticleSystem;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float paintingDistance = Vector3.Distance(PlayerTransform.position, transform.position);

	    if (paintingDistance < SpawnRadius)
	    {
	        if (!WeatherParticleSystem.isPlaying)
	        {
	            WeatherParticleSystem.Play();
	        }

	    }
	    else
	    {
            if (WeatherParticleSystem.isPlaying)
            {
                WeatherParticleSystem.Stop();
            }
	    }

	}
}
