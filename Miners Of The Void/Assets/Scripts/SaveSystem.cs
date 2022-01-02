using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

public static class SaveSystem
{
    public static string path;
    public static void Save<T>(T objectToSave,string key)
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        using (FileStream fs = new FileStream(path+key+".txt",FileMode.OpenOrCreate))
        {
            bf.Serialize(fs,objectToSave);
        }
        
    }

    public static T Load<T>(string key)
    {
        BinaryFormatter bf = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fs = new FileStream(path + key + ".txt", FileMode.OpenOrCreate))
        {
            returnValue = (T)bf.Deserialize(fs);
        }

        return returnValue;
    }

    public static bool SaveExists(string key)
    {
        string finalPath = Path.Combine(path, key);
        return File.Exists(finalPath);
    }
}
