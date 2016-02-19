using UnityEngine;
using System.Collections;

public class BackButton : Button
{
    void Start()
    {
        Load();

        nextScene = "Scenes/Hallway";
    }

    public override void OnNextScene()
    {
        Museum.CurrentFloor.ToRoom(0);
    }
}
