using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class Museum
{
    private static List<Floor> floors;
    // The current floor (starts at 0).
    private static int currentFloor = 0;

    private static string logFilePath;

    public static void Load(string setupPath, string logPath)
    {
        string currentPath = getDataPath();

        floors = new List<Floor>();

        // Load museum.
        string file = currentPath + setupPath;
        string line;
        using (StreamReader reader = new StreamReader(file))
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

            // Create logging file.
            logFilePath = currentPath + logPath;
            FileInfo f = new FileInfo(logFilePath);
            if (f.Exists)
                f.Delete();
            StreamWriter logger = f.CreateText();
            logger.WriteLine("t,fromFloor,toFloor,fromRoom,toRoom");
            logger.Close();
        }
    }

    public static string getDataPath()
    {
        if (Application.platform == RuntimePlatform.Android)
            return "/storage/emulated/0/SP/data";
        else
            return Application.persistentDataPath + "/data";
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

    public static void ToRoom(int room, bool log = true)
    {
        int fromRoom = CurrentFloor.currentRoom;
        CurrentFloor.ToRoom(room);

        if (log)
            Log(Time.time, currentFloor, currentFloor, fromRoom, room);
    }

    public static void ToNextFloor()
    {
        int fromFloor = currentFloor;
        int fromRoom = CurrentFloor.currentRoom;
        if (currentFloor < floors.Count - 1)
            currentFloor++;

        Log(Time.time, fromFloor, currentFloor, fromRoom, CurrentFloor.currentRoom);
    }

    public static void Log(float t, int fromFloor, int toFloor, int fromRoom, int toRoom)
    {
        StreamWriter logger = new StreamWriter(logFilePath, true);
        logger.WriteLine(t + "," + fromFloor + "," + toFloor + "," + fromRoom + "," + toRoom + "");
        logger.Close();
    }
}
