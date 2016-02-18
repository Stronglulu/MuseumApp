using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        Museum.Load("");
        SceneManager.LoadScene("Scenes/Hallway");
	}
}
