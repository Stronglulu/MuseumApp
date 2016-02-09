using UnityEngine;
using System.Collections;

public class Painting : MonoBehaviour
{
	void Start()
	{
        // Get the width and height of the painting texture.
        Renderer renderer = GetComponent<Renderer>();
        Texture texture = renderer.material.mainTexture;
        float paintingWidth = (float)texture.width;
        float paintingHeight = (float)texture.height;

        float proportions = paintingWidth / paintingHeight;

        // Scale the object according to the texture proportions.
        if (proportions > 1)
        {
            // Width larger than height.
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / proportions, transform.localScale.z);
        }
        else
        {
            // Height larger than width.
            transform.localScale = new Vector3(transform.localScale.x * proportions, transform.localScale.y, transform.localScale.z);
        }
    }
	
	void Update()
	{
	}
}
