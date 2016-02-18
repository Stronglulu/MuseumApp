using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        Museum.Load("/Setups/1.txt");
        SceneManager.LoadScene("Scenes/Hallway");
	}
}
