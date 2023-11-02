using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSystem
{
    public void SaveAbility(SpaceshipAbility ability)
    {
        string path = Application.persistentDataPath + "/ability.json";

        string jsonAbility = JsonUtility.ToJson(ability);
        File.WriteAllText(path, jsonAbility);

    }

    public SpaceshipAbility LoadAbility()
    {
        string path = Application.persistentDataPath + "/ability.json";

        if (File.Exists(path))
        {
            try
            {
                string jsonAbility = File.ReadAllText(path);
                return JsonUtility.FromJson<SpaceshipAbility>(jsonAbility);
            }
            catch (Exception e)
            {
                Debug.LogError("Errore caricamento file: " + e);
                return null;
            }
        }
        else
            return null;
    }
}
