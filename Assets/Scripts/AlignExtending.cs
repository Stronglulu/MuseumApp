using UnityEngine;
using System.Collections;
using System;

public class AlignExtending : MonoBehaviour
{
    public Painting painting;
    public float s = 720;

    private Renderer renderer;

	void Start()
    {
        renderer = GetComponent<Renderer>();

        LoadMaterial();
	}
	
	void Update()
    {
        ScaleTexture();
	}

    void LoadMaterial()
    {
        string paintingName = painting.paintingName;

        if (paintingName != "")
        {
            Material material = Resources.Load("Materials/Illusions/Extending/" + paintingName, typeof(Material)) as Material;
            renderer.material = material;
        }
    }

    void ScaleTexture()
    {
        Vector3 wallSize = renderer.bounds.size;
        float ratioX = (float)renderer.material.mainTexture.width / wallSize.x;
        float ratioY = (float)renderer.material.mainTexture.height / wallSize.y;
        Debug.Log("wallSize: " + wallSize);
        Debug.Log("ratioX: " + ratioX);
        Debug.Log("ratioY: " + ratioY);

        Vector3 paintingSize = painting.renderer.bounds.size;
        float maxSize = Math.Max(paintingSize.x, paintingSize.y);
        float paintingRatio = s / maxSize;
        Debug.Log("paintingRatio: " + paintingRatio);

        float xs = paintingRatio / ratioX;
        float ys = paintingRatio / ratioY;
        Debug.Log("xs: " + xs);
        Debug.Log("ys: " + ys);

        renderer.material.mainTextureScale = new Vector2(xs, ys);
        renderer.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
    }
}
