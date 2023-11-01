using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

public static class SaveSystem
{
    public static void SaveAbility(SpaceshipAbility ability)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ability.json";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, ability);
        stream.Close();
    }

    public static SpaceshipAbility LoadAbility()
    {
        string path = Application.persistentDataPath + "/ability.json";

        SpaceshipAbility data = null;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as SpaceshipAbility;
            stream.Close();
        }
        else
        {
            Debug.LogError("File non trovato in: " + path);

            data = new SpaceshipAbility
            {
                spawnRate = 1.5f,
                damage = 1,
                collisionResistance = 1
            };
        }

        return data;
    }
}
