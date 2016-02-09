using UnityEngine;
using System.Collections;

public class Painting : MonoBehaviour
{
    public string paintingName = "";

	void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (paintingName != "")
        {
            Material material = Resources.Load("Materials/Paintings/" + paintingName, typeof(Material)) as Material;
            renderer.material = material;
        }

        // Get the width and height of the painting texture.
        Texture texture = renderer.material.mainTexture;
        float paintingWidth = (float)texture.width;
        float paintingHeight = (float)texture.height;

        float proportions = paintingWidth / paintingHeight;

        // Scale the object according to the texture proportions.
        if (proportions > 1)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / proportions, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x * proportions, transform.localScale.y, transform.localScale.z);
    }
	
	void Update()
	{
	}
}
