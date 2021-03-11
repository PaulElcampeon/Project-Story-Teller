using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader
{
    public static EventCollection Load(string fileLocation)
    {
        EventCollection events =  JsonUtility.FromJson<EventCollection>(fileLocation);

        return events;
    }
}
