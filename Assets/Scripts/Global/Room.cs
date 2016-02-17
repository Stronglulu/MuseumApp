using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room
{
    public string painting;
    public Effect effect;

    public Room(string painting, Effect effect)
    {
        this.painting = painting;
        this.effect = effect;
    }
}

public enum Effect
{
    None,
    Extending,
    Stylized
}
