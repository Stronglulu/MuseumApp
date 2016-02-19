using UnityEngine;
using System.Collections;

public class TransparentWall : Overlay {
	
	// Update is called once per frame
    public override void UpdateOverlay( float val)
    {
        rend.material.SetFloat("_Blend", val);
	}
}
