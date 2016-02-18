using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class Museum
{
    public static List<Floor> floors;
    // The current floor (starts at 0).
    public static int currentFloor = 0;

    public static void Load(string path)
    {
        floors = new List<Floor>();

        string file = "";

        if (Application.platform == RuntimePlatform.Android)
        {
            // TODO: Find text file on Android.
        }
        else
        {
            string currentPath = Application.dataPath;
            file = currentPath + path;
        }


        StreamReader reader = new StreamReader(file, Encoding.Default);
        string line;
        using (reader)
        {
            List<Room> rooms = new List<Room>();

            do
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    string[] words = line.Split(' ');

                    // Empty line marks end of floor.
                    if (line.Length == 0)
                    {
                        floors.Add(new Floor(rooms));
                        rooms = new List<Room>();
                    }
                    // Two words marks a room.
                    else if (words.Length == 2)
                        rooms.Add(new Room(words[0], words[1]));
                }
            }
            while (line != null);
        }
    }

    public static Floor CurrentFloor
    {
        get
        {
            return floors[currentFloor];
        }
    }

    // Returns true when all rooms have been visited.
    public static bool CanContinue
    {
        get
        {
            // Can't continue on last floor.
            if (currentFloor == floors.Count - 1)
                return false;
            foreach (Room room in CurrentFloor.rooms)
            {
                if (!room.visited)
                    return false;
            }
            return true;
        }
    }

    public static void ToNextFloor()
    {
        if (currentFloor < floors.Count - 1)
            currentFloor++;
    }

    public static void ToRoom(int room)
    {
        CurrentFloor.currentRoom = room;

        // Mark room as visited.
        if (room > 0)
            CurrentFloor.rooms[room - 1].visited = true;
    }
}
