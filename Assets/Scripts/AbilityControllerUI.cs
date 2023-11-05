using UnityEngine;
using UnityEngine.UI;

public class AbilityControllerUI : MonoBehaviour
{
    public GameObject textMaxSpawnRate;
    public Text spawnRateDescription;

    public void SetSpawnRateDescription(float spawnRate)
    {
        spawnRateDescription.text = "Spara un proiettile ogni " + spawnRate + " secondi";
    }

    public void SetActiveTextSpawnRate()
    {
        textMaxSpawnRate.SetActive(true);
    }

}
