using System;
using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private readonly string path = Application.persistentDataPath + "/ability.csv";
    public void SaveAbility(SpaceshipAbility ability)
    {
        try
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(ability.GetRecapAbility());
            sw.Close();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public string LoadAbility()
    {
        try
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                var ability = sr.ReadLine();

                return ability;
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
}
