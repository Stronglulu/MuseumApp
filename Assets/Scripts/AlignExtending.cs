using UnityEngine;
using System.Collections;
using System;

public class AlignExtending : MonoBehaviour
{
    public Painting painting;

    private Renderer renderer;

	void Start()
    {
        renderer = GetComponent<Renderer>();

        LoadMaterial();
	}
	
	void Update()
    {
        // This is called in update to ensure the painting object is already initialized.
        ScaleTexture();
	}

    // Loads the extension material.
    void LoadMaterial()
    {
        // Use the name of the painting.
        string paintingName = painting.paintingName;
        if (paintingName != "")
        {
            Material material = Resources.Load("Materials/Illusions/Extending/" + paintingName, typeof(Material)) as Material;
            renderer.material = material;
        }
    }

    void ScaleTexture()
    {
        // Calculate the pixels per unit for the current extension texture.
        Vector3 wallSize = renderer.bounds.size;
        float ratioX = (float)renderer.material.mainTexture.width / wallSize.x;
        float ratioY = (float)renderer.material.mainTexture.height / wallSize.y;

        // Calculate the pixels per unit for the painting texture.
        Vector3 paintingSize = painting.renderer.bounds.size;
        float maxSize = Math.Max(paintingSize.x, paintingSize.y);
        float paintingRatio = Math.Max(painting.renderer.material.mainTexture.width, painting.renderer.material.mainTexture.height) / maxSize;

        // Determine the scale for the extension texture in X and Y direction.
        float xs = paintingRatio / ratioX;
        float ys = paintingRatio / ratioY;

        // Scale and center the texture.
        renderer.material.mainTextureScale = new Vector2(xs, ys);
        renderer.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
    }
}
