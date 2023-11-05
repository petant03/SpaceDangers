using System;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    public void SaveAbility(SpaceshipAbility ability)
    {
        string path = Application.persistentDataPath + "/ability.csv";

        try
        {
            if (File.Exists(path))
                File.Delete(path);

            StreamWriter sw = new StreamWriter(path);
            sw.Write(ability.ToString());
            sw.Close();

        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }


    }

    public string LoadAbility()
    {
        string path = Application.persistentDataPath + "/ability.csv";

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
