using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor
{
    public List<Room> rooms;

    public Floor(List<Room> rooms)
    {
        this.rooms = rooms;
    }
}
