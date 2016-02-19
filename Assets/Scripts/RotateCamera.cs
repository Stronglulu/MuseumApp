using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
	void Start()
    {
        Debug.Log(Museum.CurrentFloor.previousRoom);
        float angle = 180f - Museum.CurrentFloor.previousRoom * -90f;
        Debug.Log(angle);
        transform.Rotate(new Vector3(0, 1, 0), angle);
	}
}
