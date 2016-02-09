using UnityEngine;
using System.Collections;
using System;

public class OverlayCircle : Overlay
{
    protected Vector2 initialScale;

    void Start()
    {
        rend = GetComponent<Renderer>();
        function = new WaveFunction();

        ScaleTexture();
    }

    public override void UpdateOverlay()
    {
        float xs = initialScale.x * (1f - ((float)Math.Max(function.Calc(t / animationTime), 0.01f))) * 3f;
        float ys = initialScale.y * (1f - ((float)Math.Max(function.Calc(t / animationTime), 0.01f))) * 3f;
        Debug.Log(xs);
        rend.material.mainTextureScale = new Vector2(xs, ys);
        rend.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
    }

    private void ScaleTexture()
    {
        Texture texture = rend.material.mainTexture;
        float paintingWidth = (float)texture.width;
        float paintingHeight = (float)texture.height;

        Vector3 overlaySize = rend.bounds.size;
        float proportions = overlaySize.x / overlaySize.y;

        float xs, ys;
        if (proportions > 1)
        {
            xs = proportions;
            ys = 1;
        }
        else
        {
            xs = 1;
            ys = 1 / proportions;
        }

        // Scale and center the texture.
        rend.material.mainTextureScale = new Vector2(xs, ys);
        rend.material.mainTextureOffset = new Vector2(-xs / 2 + 0.5f, -ys / 2 + 0.5f);
        initialScale = rend.material.mainTextureScale;
    }
}
