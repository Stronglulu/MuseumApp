using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor
{
    public List<Room> rooms;

    // The current room. 0 = hallway, 1-3 = painting rooms.
    public int currentRoom = 0;

    public Floor(List<Room> rooms)
    {
        this.rooms = rooms;
    }

    public static Floor Empty
    {
        get
        {
            return new Floor(new List<Room>());
        }
    }

    public Room CurrentRoom
    {
        get
        {
            if (currentRoom > 0)
                return rooms[currentRoom - 1];
            else
                return null;
        }
    }
}
