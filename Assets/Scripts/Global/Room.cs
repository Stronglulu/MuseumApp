using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room
{
    // The name of the painting material.
    public string painting;

    // The name of the scene for the effect.
    public string effect;

    public string sound;

    // Indicates whether or not the user has visited this room.
    public bool visited = false;

    public Room(string painting, string effect, string sound)
    {
        this.painting = painting;
        this.effect = effect;
        this.sound = sound;
    }
}
