using UnityEngine;
using System.Collections;

public class HallwayButton : Button
{
    public int buttonIndex;

	void Start()
    {
        Load();

        Floor floor = Museum.CurrentFloor;

        // This button isn't needed.
        if (buttonIndex > floor.rooms.Count)
        {
            Destroy(transform.parent.gameObject);
        }
        // Assign correct scene.
        else
        {
            Room room = floor.rooms[buttonIndex - 1];
            nextScene = "Scenes/" + room.effect;
        }
	}

    public override void OnNextScene()
    {
        Museum.ToRoom(buttonIndex);
    }
}
