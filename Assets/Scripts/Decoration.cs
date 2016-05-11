using UnityEngine;
using System.Collections;
using System;

public class Decoration : MonoBehaviour {

    GameObject child;

	// Use this for initialization
	void Start () {

        try
        {
            child = transform.FindChild("Floor" + (Museum.currentFloor)).gameObject;
        }
        catch (Exception e)
        {
            print("no child found");
        }
        if(child != null)
            child.SetActive(true);
        

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
